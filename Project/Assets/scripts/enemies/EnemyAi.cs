// using Unity.VisualScripting;
// using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isPatroling = false;
    public bool isApproaching = false;
    public bool isAttacking = false;
    private Animator mAnimator;
    public State state;
    public enum State
    {
        Idle,
        Approach,
        Attack,
        Hit
    }
    Transform player;
    public float speed = 5.0f;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        mAnimator = GetComponent<Animator>();

        state = State.Idle;

    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        // Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        switch (state)
        {
            case State.Idle:
                Patroling();
                break;
            case State.Approach:
                Approaching();
                break;
            case State.Attack:
                Attacking();
                break;
        }
    }

    public void Patroling()
    {
        mAnimator.SetBool("Idle", true);
        mAnimator.SetBool("isApproaching", false);
        mAnimator.SetBool("isAttacking", false);

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = transform.position - walkPoint;

        // walkpoint reached

        if (distanceToWalkpoint.magnitude < 1) walkPointSet = false;
        if (playerInSightRange && !playerInAttackRange) state = State.Approach;
        if (playerInSightRange && playerInAttackRange) state = State.Attack;

    }
    public float stoppingDistance = 1f;
    private void Approaching()
    {
        mAnimator.SetTrigger("enemyShoot");
        mAnimator.SetBool("Idle", false);
        mAnimator.SetBool("isApproaching", true);
        mAnimator.SetBool("isAttacking", false);
        
        // agent.SetDestination(player.position);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the distance to the player is greater than the stopping distance
        if (distanceToPlayer > stoppingDistance)
        {
            // Calculate a point 2 units away from the player in the direction of the player
            Vector3 destinationPoint = player.position - (player.position - transform.position).normalized * stoppingDistance;

            // Set the destination to the calculated point
            agent.SetDestination(destinationPoint);
        }
        else
        {
            // Stop approaching when within the stopping distance
            agent.ResetPath();
        }

        if (playerInSightRange && playerInAttackRange) state = State.Attack;
        if (!playerInSightRange && !playerInAttackRange) state = State.Idle;
    }
    public GameObject projectile;
    public float bulletForce;
    public Transform firePoint;

    public void ShootAtPlayer()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0f; // Optional: Keep the enemy at the same height

            // Calculate the rotation needed to point at the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        GameObject bullet = Instantiate(projectile,
        firePoint.position, firePoint.rotation);
         // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        Vector3 shootDirection;
        // Check if the bullet's Rigidbody component exists
        if (bulletRb != null)
        {
            shootDirection = player.transform.position - transform.position;
            shootDirection.y = 0f;
            // Apply velocity to the bullet in the forward direction
            bulletRb.velocity = shootDirection.normalized * bulletForce;
        }
    }
    public float rotationSpeed = 8.0f;
    private void Attacking()
    {
        mAnimator.SetBool("Idle", false);
        mAnimator.SetBool("isApproaching", false);
        mAnimator.SetBool("isAttacking", true);
        if (playerInSightRange && !playerInAttackRange) state = State.Approach;
        if (!playerInSightRange && !playerInAttackRange) state = State.Idle;

        // making the enemy look at the player
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0f; // Optional: Keep the enemy at the same height

            // Calculate the rotation needed to point at the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // checks if new walkpoint is on the ground with a raycast
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    public Transform meleeHitbox;
    public void DamageAnimationEvent()
    {
        var gameManager = FindObjectOfType<PlayerhealthManager>();
        if (gameManager != null)
        {
            float radius  = 7;
            float distance = Vector3.Distance(player.position, meleeHitbox.position);
            if (distance <= radius) gameManager.PlayerTakeDamage(3);
        }
    }

}

