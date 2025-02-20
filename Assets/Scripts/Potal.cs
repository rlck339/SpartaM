using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ�

public class Potal : MonoBehaviour
{
    // Ʈ���� �浹�� �߻����� �� ����Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ������Ʈ�� "Player" �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // "ButtonScene" ������ �̵�
            SceneManager.LoadScene("ButtonScene");
        }
    }
}

