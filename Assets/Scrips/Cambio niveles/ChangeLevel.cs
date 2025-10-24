using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private int currentScene;
    private int nextScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;

            nextScene = currentScene + 1;

            if (nextScene < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
