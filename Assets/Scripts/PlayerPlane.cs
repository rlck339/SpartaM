using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    // �ִϸ����� ������Ʈ ����
    Animator animator = null;
    // Rigidbody2D ������Ʈ ����
    Rigidbody2D _rigidbody = null;

    // ����(Flap) ���� ũ��
    public float flapForce = 6f;
    // ������ �̵��ϴ� �ӵ�
    public float forwardSpeed = 3f;
    // �÷��̾� ��� ����
    public bool isDead = false;
    // ��� �� �Է��� �ޱ������ ��� �ð�
    float deathCooldown = 0f;

    // ���� �Է� ����
    bool isFlap = false;

    // ���� ��� (true�� ��� �浹�ص� ������� ����)
    public bool godMode = false;

    // ���� �Ŵ��� ����
    GameManager gameManager;

    void Start()
    {
        // �̱��� ������ ����� GameManager �ν��Ͻ� ��������
        gameManager = GameManager.Instance;

        // �ڽ� ������Ʈ���� Animator ������Ʈ ��������
        animator = transform.GetComponentInChildren<Animator>();
        // Rigidbody2D ������Ʈ ��������
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        // Animator�� �������� ���� ��� ���� �޽��� ���
        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        // Rigidbody2D�� �������� ���� ��� ���� �޽��� ���
        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        // �÷��̾ ����� ���
        if (isDead)
        {
            // ��� ��� �ð��� 0 ������ ���� �Է� ����
            if (deathCooldown <= 0)
            {
                // Space Ű �Ǵ� ���콺 Ŭ�� �� ���� �����
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                // ��� ��� �ð� ����
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            // Space Ű �Ǵ� ���콺 Ŭ�� �� ���� �÷��� Ȱ��ȭ
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        // �÷��̾ ����� ��� �������� ����
        if (isDead)
            return;

        // ���� �ӵ� ��������
        Vector3 velocity = _rigidbody.velocity;
        // x�� �ӵ��� ������ ������ ����
        velocity.x = forwardSpeed;

        // ���� �Է��� �����Ǿ��� ��� y�� �ӵ� ����
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        // Rigidbody2D�� �ӵ� ����
        _rigidbody.velocity = velocity;

        // ���� �ӵ��� ������� ����(angle) ��� (-90 ~ 90�� ���� ����)
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        // �ε巯�� ȸ�� ����
        float lerpAngle = Mathf.Lerp(_rigidbody.velocity.y, angle, Time.deltaTime * 5f);
        // ������Ʈ�� ȸ�� ����
        transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ��尡 Ȱ��ȭ�� ��� �浹 ����
        if (godMode)
            return;

        // �̹� ����� ���¶�� �ٽ� ó������ ����
        if (isDead)
            return;

        // �ִϸ������� "IsDie" ���� 1�� �����Ͽ� ��� �ִϸ��̼� ���
        animator.SetInteger("IsDie", 1);
        // �÷��̾� ��� ó��
        isDead = true;
        // ��� �� �Է� ��� �ð� ����
        deathCooldown = 1f;

        // ���� ���� ó��
        gameManager.GameOver();
    }
}
