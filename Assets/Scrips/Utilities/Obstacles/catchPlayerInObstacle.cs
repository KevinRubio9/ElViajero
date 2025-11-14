using System;
using UnityEngine;

public class catchPlayerInObstacle : MonoBehaviour
{
    PlayerController playerController;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();    
    }
    private void Update()
    {
        if(!playerController.isGrounded)
        {
            transform.parent = null;
        }
    }
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Platform") && playerController.isGrounded)
        {
            transform.SetParent(hit.transform);
           
        }
    }
}
