using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

public class EnemyMoveController : MonoBehaviour
{
    StatesBase currentStatus;
    public LifeController life;

    [Header("Components")]

    public Animator anim;
    public NavMeshAgent agent;

    [Header("Player")]
    public Transform targetAgent;
    public float actionDistance = 5f;
    [SerializeField] public float currDistance;

    [Header("Patrol")]
    public List<Transform> patrolPoints;
    [HideInInspector] public int currentPoint = 0;
    [HideInInspector] public float waitCounter;
    public float waitTime = 2f;
    public float patrolSpeed = 2f;

    [Header("Tackle")]
    public float tackleSpeed = 10f;
    public float tacklePause = 0.5f;
    [HideInInspector] public float lastTackleTime;

    // States
    public PatrolState patrol;
    public TackleState tackle;
    public ChaseState Chase;
    public DeadState Dead;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        life = GetComponent<LifeController>();
    }
    void Start()
    {
        patrol = new PatrolState(this);
        Chase = new ChaseState(this);
        tackle = new TackleState(this);
        Dead = new DeadState(this);

        ChangeStatus(patrol);

        foreach (Transform t in patrolPoints)
        {
            t.SetParent(null);
        }
    }

    void Update()
    {
        if (currentStatus != null)
        {
            currentStatus.UpdateState();

        }

    }

    public void HandleDead()
    {
        ChangeStatus(Dead);
    }
    public void ChangeStatus(StatesBase newStatus)
    {
        if (currentStatus == newStatus) return;

        
        if (currentStatus != null)
        {
            currentStatus.ExitState(newStatus);
        }

        currentStatus = newStatus;
        currentStatus.EnterState();
    }


}
