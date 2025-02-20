using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseController
{
    // ���� ī�޶� �����ϱ� ���� ����
    private Camera camera;

    // ������ ���۵� �� ����Ǵ� �Լ� (Unity�� Start() �޼���)
    protected override void Start()
    {
        base.Start(); // �θ� Ŭ����(BaseController)�� Start() ����
        camera = Camera.main; // ���� ���� ���� ī�޶� ������
    }

    // �÷��̾��� �̵� �� ���콺 ���� ó���� ����ϴ� �Լ�
    protected override void HandleAction()
    {
        // Ű���� �Է��� �޾Ƽ� �̵� ���� ���� (WASD / ����Ű)
        float horizontal = Input.GetAxisRaw("Horizontal"); // ����(-1) / ������(+1)
        float vertial = Input.GetAxisRaw("Vertical");      // �Ʒ�(-1) / ��(+1)
        movementdirection = new Vector2(horizontal, vertial).normalized; // �밢�� �̵� �� �ӵ� ������ ���� ����ȭ

        // ���콺 ��ġ�� ȭ�� ��ǥ���� ��������
        Vector2 mousePosition = Input.mousePosition;

        // ���콺 ��ǥ�� ���� ��ǥ�� ��ȯ (2D ȯ�� ����)
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

        // �÷��̾� ��ġ�� �������� ���콺 ���� ���� ���
        lookDirection = (worldPos - (Vector2)transform.position);

        // ���� ���콺 ���� ������ ���̰� �ʹ� ª���� (�Ÿ��� 0.9 �̸��̸�)
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero; // ���� �ʱ�ȭ
        }
        else
        {
            lookDirection = lookDirection.normalized; // ���� ���͸� ����ȭ
        }
    }
}
