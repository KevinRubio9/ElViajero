using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using JetBrains.Annotations;

public class WeakPointBoss : MonoBehaviour
{
    [SerializeField] FinalBossLogic Boss;
    public bool active;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        active = true;
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("BulletP"))
        {
            StartCoroutine(Boss.Hurt());
            Invoke("DisableObject", 2.1f);
        }
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        active = false;
    }

}
