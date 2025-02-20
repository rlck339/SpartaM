using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    // 애니메이터 컴포넌트 참조
    Animator animator = null;
    // Rigidbody2D 컴포넌트 참조
    Rigidbody2D _rigidbody = null;

    // 점프(Flap) 힘의 크기
    public float flapForce = 6f;
    // 앞으로 이동하는 속도
    public float forwardSpeed = 3f;
    // 플레이어 사망 여부
    public bool isDead = false;
    // 사망 후 입력을 받기까지의 대기 시간
    float deathCooldown = 0f;

    // 점프 입력 감지
    bool isFlap = false;

    // 무적 모드 (true일 경우 충돌해도 사망하지 않음)
    public bool godMode = false;

    // 게임 매니저 참조
    GameManager gameManager;

    void Start()
    {
        // 싱글톤 패턴을 사용한 GameManager 인스턴스 가져오기
        gameManager = GameManager.Instance;

        // 자식 오브젝트에서 Animator 컴포넌트 가져오기
        animator = transform.GetComponentInChildren<Animator>();
        // Rigidbody2D 컴포넌트 가져오기
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        // Animator가 존재하지 않을 경우 오류 메시지 출력
        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        // Rigidbody2D가 존재하지 않을 경우 오류 메시지 출력
        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        // 플레이어가 사망한 경우
        if (isDead)
        {
            // 사망 대기 시간이 0 이하일 때만 입력 감지
            if (deathCooldown <= 0)
            {
                // Space 키 또는 마우스 클릭 시 게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                // 사망 대기 시간 감소
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            // Space 키 또는 마우스 클릭 시 점프 플래그 활성화
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        // 플레이어가 사망한 경우 동작하지 않음
        if (isDead)
            return;

        // 현재 속도 가져오기
        Vector3 velocity = _rigidbody.velocity;
        // x축 속도를 앞으로 가도록 설정
        velocity.x = forwardSpeed;

        // 점프 입력이 감지되었을 경우 y축 속도 증가
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        // Rigidbody2D의 속도 적용
        _rigidbody.velocity = velocity;

        // 현재 속도를 기반으로 기울기(angle) 계산 (-90 ~ 90도 범위 제한)
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        // 부드러운 회전 적용
        float lerpAngle = Mathf.Lerp(_rigidbody.velocity.y, angle, Time.deltaTime * 5f);
        // 오브젝트의 회전 적용
        transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 무적 모드가 활성화된 경우 충돌 무시
        if (godMode)
            return;

        // 이미 사망한 상태라면 다시 처리하지 않음
        if (isDead)
            return;

        // 애니메이터의 "IsDie" 값을 1로 설정하여 사망 애니메이션 재생
        animator.SetInteger("IsDie", 1);
        // 플레이어 사망 처리
        isDead = true;
        // 사망 후 입력 대기 시간 설정
        deathCooldown = 1f;

        // 게임 오버 처리
        gameManager.GameOver();
    }
}
