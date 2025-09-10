using UnityEngine;

public class FinalBossLogic : MonoBehaviour
{

    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookTarget()
    {
        Vector3 direction = transform.position - player.position;

    }
}
