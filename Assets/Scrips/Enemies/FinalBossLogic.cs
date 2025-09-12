using UnityEngine;

public class FinalBossLogic : MonoBehaviour
{

    public Transform player;
    public float sdRotate;
    BulletPoolBoss bulletPool;
    public Transform pointBullet1;
    public Transform pointBullet2;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPool = FindAnyObjectByType<BulletPoolBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        LookTarget();
    }

    public void LookTarget()
    {
        Vector3 direction = transform.position - player.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sdRotate * Time.deltaTime);
        }
    }
    
    public void Shoot()
    {
        int randomlist = Random.Range(0, 2);
        if(1==1)
        {

        }
        GameObject bulletAvaiable = bulletPool.UseBullet(randomlist);
        bulletAvaiable.SetActive(true);
        bulletAvaiable.transform.position = pointBullet1.position;
        bulletAvaiable.transform.rotation = pointBullet1.rotation;
    }
}
