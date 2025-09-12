using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WeakPointBoss : MonoBehaviour
{
    private bool active = false;
    public float timeActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BulletP"))
        {
            StartCoroutine(WeakPointActive());
        }
    }

    IEnumerator WeakPointActive()
    {
        active = true;

        yield return new WaitForSeconds(timeActive); 
        active = false;
    }
}
