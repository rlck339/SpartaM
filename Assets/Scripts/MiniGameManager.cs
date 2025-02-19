using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    // 미니게임 시작 버튼이 눌렸을 때 실행
    public void StartMiniGame()
    {
        Debug.Log("미니게임 시작!");
        // 미니게임 로직을 여기에 추가할 수 있음
    }

    // 메인 씬으로 돌아가는 버튼이 눌렸을 때 실행
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene"); // 메인 씬 이름을 정확하게 입력해야 함
    }
}