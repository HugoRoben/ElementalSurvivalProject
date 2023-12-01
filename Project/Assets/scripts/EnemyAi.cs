using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    // attacking
    // States
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
    public float speed = 5.0f;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        mAnimator = GetComponent<Animator>();

        state = State.Idle;

    }

    int begin;
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

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

    private void Approaching()
    {
        mAnimator.SetBool("Idle", false);
        mAnimator.SetBool("isApproaching", true);
        mAnimator.SetBool("isAttacking", false);
        agent.SetDestination(player.position);
        if (playerInSightRange && playerInAttackRange) state = State.Attack;
        if (!playerInSightRange && !playerInAttackRange) state = State.Idle;
    }
    // public EnemyAttackCollision enemyAttackCollision;
    public float rotationSpeed = 5.0f;
    private void Attacking()
    {
        // Debug.Log("attack");
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
}

