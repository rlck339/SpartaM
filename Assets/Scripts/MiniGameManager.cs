using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    // �̴ϰ��� ���� ��ư�� ������ �� ����
    public void StartMiniGame()
    {
        Debug.Log("�̴ϰ��� ����!");
        // �̴ϰ��� ������ ���⿡ �߰��� �� ����
    }

    // ���� ������ ���ư��� ��ư�� ������ �� ����
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene"); // ���� �� �̸��� ��Ȯ�ϰ� �Է��ؾ� ��
    }
}