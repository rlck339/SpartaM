using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // Rigidbody2D ������Ʈ ����
    protected Rigidbody2D _rigidbody;

    // ĳ������ ��������Ʈ ������ (�¿� ���� �뵵)
    [SerializeField] private SpriteRenderer chracterRenderer;

    // �̵� ���� ���� (�ڽ� Ŭ�������� ���� ����)
    protected Vector2 movementdirection = Vector2.zero;
    // �̵� ������ �ܺο��� ���� �� �ֵ��� public �Ӽ� ����
    public Vector2 MovementDirection { get { return movementdirection; } }

    // �ٶ󺸴� ���� ����
    protected Vector2 lookDirection = Vector2.zero;
    // �ٶ󺸴� ������ �ܺο��� ���� �� �ֵ��� public �Ӽ� ����
    public Vector2 LookDirection { get { return lookDirection; } }

    // ��ü�� ������ �� ȣ��Ǵ� �ʱ�ȭ �Լ�
    protected virtual void Awake()
    {
        // Rigidbody2D ������Ʈ ��������
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start()�� ����Ƽ���� ù �������� ���۵� �� ȣ��Ǵ� �Լ�
    protected virtual void Start()
    {

    }

    // Update()�� �� �����Ӹ��� ȣ��Ǵ� �Լ�
    protected virtual void Update()
    {
        // �ൿ ó�� (�ڽ� Ŭ�������� �������̵� ����)
        HandleAction();
        // ĳ���Ͱ� �ٶ󺸴� �������� ȸ�� ó��
        Rotate(lookDirection);
    }

    // FixedUpdate()�� ���� ������ ó���� �� ������ �������� ȣ���
    protected virtual void FixedUpdate()
    {
        // �̵� ó��
        Movement(movementdirection);
    }

    // ĳ������ �ൿ�� ó���ϴ� �Լ� (�ڽ� Ŭ�������� �������̵� ����)
    protected virtual void HandleAction()
    {

    }

    /// <summary>
    /// ĳ���� �̵� ó��
    /// </summary>
    /// <param name="direction">�̵��� ����</param>
    private void Movement(Vector2 direction)
    {
        // �̵� �ӵ� ���� (���� �ӵ��� 5)
        direction = direction * 5;

        // Rigidbody2D�� �ӵ� ����
        _rigidbody.velocity = direction;
    }

    /// <summary>
    /// ĳ������ ������ ȸ����Ŵ
    /// </summary>
    /// <param name="direction">�ٶ� ����</param>
    private void Rotate(Vector2 direction)
    {
        // ȸ�� ���� ��� (���� -> ��)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // -90�� ~ 90�� ������ ������ �ٶ󺸴� ����
        bool isLeft = Mathf.Abs(rotZ) < 90f;

        // ��������Ʈ ������ �����Ͽ� ĳ���Ͱ� �ڿ������� ȸ���ϵ��� ����
        chracterRenderer.flipX = isLeft;
    }
}




