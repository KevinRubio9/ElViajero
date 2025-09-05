using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Player")]
    public Transform targetAgent;
    public float actionDistance = 5f;
    public float currDistance;

    [Header("Patrulla")]
    public List<Transform> patrolPoints;
    private int currentPoint = 0;
    public float waitTime = 2f;  // Tiempo entre puntos de patrulla
    private float waitCounter; // Contador para el tiempo de espera entre los puntos


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
     
    }

    void Start()
    {
        if (patrolPoints.Count > 0)
        {
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    void Update()
    {
        currDistance = Vector3.Distance(transform.position, targetAgent.position);

        if (currDistance <= actionDistance)
        {
            agent.SetDestination(targetAgent.position);
        }
        else
        {

            if (patrolPoints.Count == 0) return;

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (waitCounter <= 0f)
                {
                    currentPoint = (currentPoint + 1) % patrolPoints.Count;
                    agent.SetDestination(patrolPoints[currentPoint].position);
                    waitCounter = waitTime;
                }
                else
                {
                    waitCounter -= Time.deltaTime;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.transform.position - transform.position;

            collision.gameObject.GetComponent<PlayerController>().Tackle(pushDirection, 5f);
        }
    }
}




