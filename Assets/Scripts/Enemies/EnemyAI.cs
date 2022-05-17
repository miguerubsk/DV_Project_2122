using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField] NavMeshAgent agent;
    //[SerializeField] Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] GameObject player;
    [SerializeField] Collider cubo;

    [Header("Patrolling")]
    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;

    [Header("Attacking")]
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    [Header("States")]
    [SerializeField] float sightRange, attackRange;
    [SerializeField] bool playerInSightRange, playerInAttackRange;

    private void Awake() {
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //this.transform.position.Set(transform.position.x, 0.5f, transform.position.z);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && !playerInSightRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        //if(playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    private void Patrolling() {
        if (walkPointSet) {
            agent.SetDestination(walkPoint);
        } else {
            SearchWalkPoint();
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void ChasePlayer() {
        agent.SetDestination(GameObject.Find("PlayerArmature").transform.position);
    }

    private void AttackPlayer() {

        //Enemy don't move
        agent.SetDestination(transform.position);

        //Look at player
        transform.LookAt(player.transform);

        if (!alreadyAttacked) {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void SearchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Player???????");
        if (other.tag == "Player")
        {
            Debug.Log("PLAYER");
            cubo.enabled = false;
            GameObject.FindObjectOfType<GameManager>().Hurt();
        }

    }
}
