using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManagerStateMachine : MonoBehaviour
{
    //create an enum tht will handle what state the enemy is in
    public enum EnemyState
    {
        patrol,
        chase,
        attack
    }

    public EnemyState enemyState;
    //Editor UI headers
    [Space]
    [Header("Patrol Variables")]
    [Space]
    public Transform[] patrolPoints;
    public float patrolSpeed = 3;

    [Space]
    [Header("Chase Variables")]
    [Space]
    public float chaseSpeed = 5;
    public float detectionRange = 10;

    [Space]
    [Header("Attack Variables")]
    [Space]
    public float attackRange = 2;
    public float attackDelay = 2;

    [Space]
    [Header("Projectiles")]
    [Space]
    public GameObject projectile;
    public Transform spawnPosition;

    private NavMeshAgent agent;
    private Transform player;
    private int currentPatrolIndex = 0;
    private float attackTimer = 0;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.patrol;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = patrolSpeed;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (enemyState == EnemyState.patrol && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }

        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer < attackRange)
            {
                enemyState = EnemyState.attack;
                agent.SetDestination(transform.position);
                agent.transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                spawnPosition.LookAt(player);

                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(Attack());
                }

            }
            else
            {
                enemyState = EnemyState.chase;
                agent.SetDestination(player.position);
                agent.speed = chaseSpeed;
            }
        }
        else
        {
            enemyState = EnemyState.patrol;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
            agent.speed = patrolSpeed;
        }
    }

    IEnumerator Attack()
    {
        GameObject bullet = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation, null);

        yield return new WaitForSeconds(attackDelay);

        isAttacking = false;
    }
}
