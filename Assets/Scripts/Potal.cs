using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    [SerializeField] private string minigameSceneName = "MiniGameScene";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            SceneManager.LoadScene(minigameSceneName);
        }
    }
}

