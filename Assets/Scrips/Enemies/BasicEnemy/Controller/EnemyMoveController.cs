using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    StatesBase currentStatus;

    [Header("Components")]

    //public Animator anim;
    [SerializeField] public NavMeshAgent agent;

    [Header("Player")]
    public Transform targetAgent;
    public float actionDistance = 5f;
    [HideInInspector] public float currDistance;

    [Header("Patrol")]
    public List<Transform> patrolPoints;
    [HideInInspector] public int currentPoint = 0;
    [HideInInspector] public float waitCounter;
    public float waitTime = 2f;
    public float patrolSpeed = 2f;

    [Header("Tackle")]
    public float tackleSpeed = 5f;

    // States
    public PatrolState patrol;
    public TackleState tackle;
    public ChaseState Chase;

    public void Awake()
    {
        //anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        patrol = new PatrolState(this);
        Chase = new ChaseState(this);
        tackle = new TackleState(this);

        ChangeStatus(patrol);
    }

    void Update()
    {
        if (currentStatus != null)
        {
            currentStatus.UpdateState();
        }

    }
    public void ChangeStatus(StatesBase newStatus)
    {
        currentStatus = newStatus;
        currentStatus.EnterState();
    }


}
