using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFighter : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    // Gonna be used to help the CPU how to move what they are actually gonna be moving towards (the player)
    // and when they are on the ground (especially since the jumping goes really high)
    public LayerMask whatisFloor, whatisPlayer;

    // Used to establish the rigidbody in the code
    public Rigidbody enemyRB;

    // Moving left and right, "Shimmying"
    public Vector3 shimmyPoint;
    bool shimmyPointSet;
    public float shimmyPointRange = 12.2f;
    // Jumping
    public float timeBetweenJumps;



    // Shooting Projectiles, attacking (work on later)
    public float timeBetweenAttacks;


    // The different states the AI can be in (work on later)
    public float attackRange;
    public bool playerInAttackLine;



    private void Awake()
    {
        player = GameObject.Find("Player Fighter").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    private void Shimmying()
    {
        if (!shimmyPointSet) SearchShimmyPoint();

        if (shimmyPointSet)
            agent.SetDestination(shimmyPoint);

        Vector3 distanceToShimmyPoint = transform.position - shimmyPoint;

        // shimmy point reached

        if (distanceToShimmyPoint.magnitude < 1f)
            shimmyPointSet = false;
    }

    private void SearchShimmyPoint()
    {
        float randomZ = Random.Range(-shimmyPointRange, shimmyPointRange);

        shimmyPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(shimmyPoint, -transform.up, 2f, whatisFloor))
            shimmyPointSet = true;
    }




    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
