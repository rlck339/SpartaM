using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseController
{
    // 메인 카메라를 참조하기 위한 변수
    private Camera camera;

    // 게임이 시작될 때 실행되는 함수 (Unity의 Start() 메서드)
    protected override void Start()
    {
        base.Start(); // 부모 클래스(BaseController)의 Start() 실행
        camera = Camera.main; // 현재 씬의 메인 카메라를 가져옴
    }

    // 플레이어의 이동 및 마우스 방향 처리를 담당하는 함수
    protected override void HandleAction()
    {
        // 키보드 입력을 받아서 이동 방향 결정 (WASD / 방향키)
        float horizontal = Input.GetAxisRaw("Horizontal"); // 왼쪽(-1) / 오른쪽(+1)
        float vertial = Input.GetAxisRaw("Vertical");      // 아래(-1) / 위(+1)
        movementdirection = new Vector2(horizontal, vertial).normalized; // 대각선 이동 시 속도 조절을 위해 정규화

        // 마우스 위치를 화면 좌표에서 가져오기
        Vector2 mousePosition = Input.mousePosition;

        // 마우스 좌표를 월드 좌표로 변환 (2D 환경 기준)
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

        // 플레이어 위치를 기준으로 마우스 방향 벡터 계산
        lookDirection = (worldPos - (Vector2)transform.position);

        // 만약 마우스 방향 벡터의 길이가 너무 짧으면 (거리가 0.9 미만이면)
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero; // 방향 초기화
        }
        else
        {
            lookDirection = lookDirection.normalized; // 방향 벡터를 정규화
        }
    }
}
