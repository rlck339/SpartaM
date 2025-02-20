using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필요

public class Potal : MonoBehaviour
{
    // 트리거 충돌이 발생했을 때 실행되는 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            // "ButtonScene" 씬으로 이동
            SceneManager.LoadScene("ButtonScene");
        }
    }
}

