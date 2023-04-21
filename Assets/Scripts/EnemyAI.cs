
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, playerInLineOfSight;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInLineOfSight = CheckLineOfSight();

        if ((!playerInSightRange && !playerInAttackRange) || !playerInLineOfSight) Patroling();
        if (playerInSightRange && !playerInAttackRange && playerInLineOfSight) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && playerInLineOfSight) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            ///Attack code here
            var projectileObj = Instantiate(projectile, transform.position + (player.position - transform.position).normalized / 10, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (player.position - transform.position).normalized;
            Debug.Log("Shot");
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private bool CheckLineOfSight()
    {
        if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out RaycastHit hit))
        {
            // Check if the ray hit the target object
            if (hit.transform == player)
            {
                // The target is visible, return true
                return true;
            }
        }

        // The target is not visible, return false
        return false;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
