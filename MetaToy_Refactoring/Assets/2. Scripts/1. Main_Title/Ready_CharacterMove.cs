using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ready_CharacterMove.cs
// 1. 캐릭터를 일정한 간격으로 무작위 방향으로 움직이게 함
// 2. 캐릭터가 땅에서 떨어지기 전 방향을 전환하게 함

public class Ready_CharacterMove : MonoBehaviour
{
    #region *** Variable Declare ***

    [Header("[ FadeOut Sprite ]")]
    public SpriteRenderer[] spriteRenderers;

    Rigidbody2D rigid;
    SpriteRenderer sprite;

    private float duration = .25f; // 페이드 아웃 시간

    private int nextMove = 1;   // 다음 이동 방향

    private int floorLayerMask; // 바닥 레이어 마스크

    // 상수들을 정의
    private const float ThinkDelay = 0.5f;
    private const float TurnDelay = 2f;
    private const float MinThinkTime = 1f;
    private const float MaxThinkTime = 5f;

    #endregion

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // 바닥 레이어 마스크를 가져옴
        floorLayerMask = LayerMask.GetMask("Ready_Floor");

        // Think 함수를 0.5초 지연 후 호출
        Invoke("Think", ThinkDelay);
    }

    private void FixedUpdate()
    {
        // 캐릭터의 가로 속도 업데이트
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // 캐릭터의 스프라이트 방향 지정
        sprite.flipX = Mathf.Sign(nextMove) == -1;

        // 캐릭터의 예상 이동 방향의 앞 위치 계산
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);

        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        // ray를 통한 바닥 감지
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 5, floorLayerMask);

        // 바닥이 없다면 Turn() 함수 호출
        if (rayHit.collider == null)
            Turn();
    }

    void Turn() //  캐릭터 방향을 전환
    {
        nextMove *= -1;

        CancelInvoke();
        Invoke("Think", TurnDelay);
    }
    
    void Think()    // 캐릭터의 다음 이동 방향 결정
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(MinThinkTime, MaxThinkTime);
        Invoke("Think", nextThinkTime);
    }

    void FadeOut()
    {
        StartCoroutine("FadeOutSprites");
    }

    // 캐릭터 페이드 아웃
    IEnumerator FadeOutSprites()
    {
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, t / duration);

            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                Color col = renderer.color;
                col.a = alpha;
                renderer.color = col;
            }

            yield return null;
        }
    }
}
