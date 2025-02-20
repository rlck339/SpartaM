using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // Rigidbody2D 컴포넌트 참조
    protected Rigidbody2D _rigidbody;

    // 캐릭터의 스프라이트 렌더러 (좌우 반전 용도)
    [SerializeField] private SpriteRenderer chracterRenderer;

    // 이동 방향 벡터 (자식 클래스에서 접근 가능)
    protected Vector2 movementdirection = Vector2.zero;
    // 이동 방향을 외부에서 읽을 수 있도록 public 속성 제공
    public Vector2 MovementDirection { get { return movementdirection; } }

    // 바라보는 방향 벡터
    protected Vector2 lookDirection = Vector2.zero;
    // 바라보는 방향을 외부에서 읽을 수 있도록 public 속성 제공
    public Vector2 LookDirection { get { return lookDirection; } }

    // 객체가 생성될 때 호출되는 초기화 함수
    protected virtual void Awake()
    {
        // Rigidbody2D 컴포넌트 가져오기
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start()는 유니티에서 첫 프레임이 시작될 때 호출되는 함수
    protected virtual void Start()
    {

    }

    // Update()는 매 프레임마다 호출되는 함수
    protected virtual void Update()
    {
        // 행동 처리 (자식 클래스에서 오버라이드 가능)
        HandleAction();
        // 캐릭터가 바라보는 방향으로 회전 처리
        Rotate(lookDirection);
    }

    // FixedUpdate()는 물리 연산을 처리할 때 일정한 간격으로 호출됨
    protected virtual void FixedUpdate()
    {
        // 이동 처리
        Movement(movementdirection);
    }

    // 캐릭터의 행동을 처리하는 함수 (자식 클래스에서 오버라이드 가능)
    protected virtual void HandleAction()
    {

    }

    /// <summary>
    /// 캐릭터 이동 처리
    /// </summary>
    /// <param name="direction">이동할 방향</param>
    private void Movement(Vector2 direction)
    {
        // 이동 속도 설정 (현재 속도는 5)
        direction = direction * 5;

        // Rigidbody2D에 속도 적용
        _rigidbody.velocity = direction;
    }

    /// <summary>
    /// 캐릭터의 방향을 회전시킴
    /// </summary>
    /// <param name="direction">바라볼 방향</param>
    private void Rotate(Vector2 direction)
    {
        // 회전 각도 계산 (라디안 -> 도)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // -90도 ~ 90도 범위면 왼쪽을 바라보는 상태
        bool isLeft = Mathf.Abs(rotZ) < 90f;

        // 스프라이트 방향을 반전하여 캐릭터가 자연스럽게 회전하도록 설정
        chracterRenderer.flipX = isLeft;
    }
}




