using System.Collections.Generic;
using System.Timers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterLogic : MonoBehaviour
{
    public Animator anim;
    [SerializeField] Transform player;
    LifeController lifeEnemy;

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

    //Dead


    // Update is called once per frame
    private void Start()
    {
        


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
        
        pinnedPlayer = Physics.Raycast(transform.position, transform.forward, distanceDetection, layerPlayer);
        if (isPatrolling && !playerDetected)
        {
            agent.angularSpeed = 120f;
            anim.SetBool("Player Detected",false);
            Patrol();
        }
        else if (playerDetected)
        {
            LookTarget();
            agent.SetDestination(transform.position);
            agent.updateRotation = false;
            anim.SetBool("Player Detected", true);
            //if (playerInZone && Time.time >= rateTimeShoot)
            //{
            //    Shoot();
            //    rateTimeShoot = Time.time + fireRate;
            //}
        }

        if(lifeEnemy.currentHealth <= 0)
        {
            DeadCogollo();
        }

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
    public void Patrol()
    {
        agent.updateRotation = true;
        agent.stoppingDistance = 0;
        float distanceTarget = Vector3.Distance(agent.transform.position, pointsMov[currentTargert].position);

        if (distanceTarget <= maxDistance)
        {
            currentTargert++;
            if (currentTargert >= pointsMov.Count)
            { currentTargert = 0; }
        }
        agent.SetDestination(pointsMov[currentTargert].position);

        Debug.Log("Cogollo se esta dirigiendo al punto numero: " + currentTargert);
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

    public void DeadCogollo()
    {
        Debug.Log("Cogollo ha muerto");
        anim.SetBool("Enemy Alive", false);
        agent.SetDestination(transform.position);
        isPatrolling = false;
        playerDetected = false;
        this.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * distanceDetection);
    }
}


