using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterLogic : MonoBehaviour
{
    public Animator anim;
    [SerializeField] Transform player;
    LifeController lifeEnemy;

    //statemachine

    BaseStateCogollo currentState;
    public PatrolStateCogollo patrol;
    public ShootStateCogollo shoot;
    public DeadStateCogollo dead;

    //patrol
    public NavMeshAgent agent;
    public bool isPatrolling = true;
    public bool playerDetected;
    public List<Transform> pointsMov;
    public int currentTargert = 0;
    public float maxDistance;
    [SerializeField] float rotationSd;


    //shoot
    BulletPoolEnemies bulletPool;
    [SerializeField] Transform pointBullet;
    public float fireRate;
    public float rateTimeShoot;
    public bool pinnedPlayer;
    public bool playerInZone;
    public float distanceDetection;
    public LayerMask layerPlayer;


    // Update is called once per frame
    private void Start()
    {
        patrol = new PatrolStateCogollo(this);
        shoot = new ShootStateCogollo(this);
        dead = new DeadStateCogollo(this);


        bulletPool = FindAnyObjectByType<BulletPoolEnemies>();
        agent = GetComponent<NavMeshAgent>();
        lifeEnemy = GetComponent<LifeController>();

        foreach (Transform t in pointsMov)
        {
            t.SetParent(null);
        }

    }
    void Update()
    {
        currentState?.UpdateState();
        pinnedPlayer = Physics.Raycast(transform.position, transform.forward, distanceDetection, layerPlayer);
        if (isPatrolling && !playerDetected)
        {
            ChangeState(patrol);
        }
    }
    public void ChangeState(BaseStateCogollo newState)
    {
        currentState = newState;
        currentState.EnterState();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPatrolling = false;
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPatrolling = true;
            playerDetected = false;
            playerInZone = false;
        }
    }

    public void LookTarget()
    {
        Vector3 direction = player.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSd * Time.deltaTime);
        }

        if (pinnedPlayer)
        {
            playerInZone = true;
        }

    }
    public void Shoot()
    {

        GameObject bulletAvaiable = bulletPool.UseBullet();
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointBullet.position;
        bulletAvaiable.transform.rotation = pointBullet.rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * distanceDetection);
    }
}


