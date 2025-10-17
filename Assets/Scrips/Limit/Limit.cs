using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Limit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("DiseñoTutorial");
        }
    }
}
