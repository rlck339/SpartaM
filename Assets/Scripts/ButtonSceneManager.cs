using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneManager : MonoBehaviour
{
    public Button startButton; // 미니게임으로 가는 버튼
    public Button backButton;  // 메인 씬으로 돌아가는 버튼

    private void Start()
    {
        // 버튼에 기능 연결
        startButton.onClick.AddListener(LoadMiniGameScene);
        backButton.onClick.AddListener(LoadMainScene);
    }

    // 미니게임 씬으로 이동
    public void LoadMiniGameScene()
    {
        SceneManager.LoadScene("MiniGameScene"); // ✅ 미니게임 씬 이름을 정확히 입력!
    }

    // 메인 씬으로 돌아가기
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene"); // ✅ 메인 씬 이름을 정확히 입력!
    }
}

