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
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile; 



    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isPatroling = false;
    public bool isApproaching = false;
    public bool isAttacking = false;

    // public enum State
    // {
    //     Idle
    // }

    // WaveSpawner Spawner;
    // public void SetSpawner(WaveSpawner _spawner)
    // {
    //     Spawner = _spawner;
    // }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        // state = State.Idle;
    }

    private void Update()
    {

        // switch (State)
        // {
        //     case 
        // }


        // check if player is inn sight/ attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && !playerInSightRange) 
        {
            Patroling();
            isPatroling = true;
            isApproaching = false;
            isAttacking = false;
        }
        
        if (playerInSightRange && !playerInAttackRange) 
        {
            ChasePlayer();
            isApproaching = true;
            isPatroling = false;
            isAttacking = false;
        }
        if (playerInAttackRange && playerInSightRange) 
        {
            // AttackPlayer();
            ChasePlayer();
            isApproaching = false;
            isPatroling = false;
            isAttacking = true;
        }
    }

    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = transform.position - walkPoint;

        // walkpoint reached

        if (distanceToWalkpoint.magnitude < 1) walkPointSet = false;
        
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // checks if new walkpoint is on the ground with a raycast
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

}
