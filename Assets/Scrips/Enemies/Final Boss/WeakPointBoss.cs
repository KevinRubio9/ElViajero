using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class WeakPointBoss : MonoBehaviour
{
    public bool active = false;
    public float timeActive;
    public float currentTime = 0f;
    Coroutine coroutineActiveWeak;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("BulletP"))
        {

            if (coroutineActiveWeak != null )
            {
                StopCoroutine(TimeActivePoint());
            }
            collision.gameObject.SetActive(false);
            coroutineActiveWeak = StartCoroutine(TimeActivePoint());
        }
    }

    public IEnumerator TimeActivePoint()
    {
        active = true;
        yield return new WaitForSeconds(timeActive);
        active = false;

        coroutineActiveWeak = null;
    }

}
