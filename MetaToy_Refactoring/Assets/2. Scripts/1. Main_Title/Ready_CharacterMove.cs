using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ready_CharacterMove.cs
// 1. ĳ���͸� ������ �������� ������ �������� �����̰� ��
// 2. ĳ���Ͱ� ������ �������� �� ������ ��ȯ�ϰ� ��

public class Ready_CharacterMove : MonoBehaviour
{
    #region *** Variable Declare ***

    [Header("[ FadeOut Sprite ]")]
    public SpriteRenderer[] spriteRenderers;

    Rigidbody2D rigid;
    SpriteRenderer sprite;

    private float duration = .25f; // ���̵� �ƿ� �ð�

    private int nextMove = 1;   // ���� �̵� ����

    private int floorLayerMask; // �ٴ� ���̾� ����ũ

    // ������� ����
    private const float ThinkDelay = 0.5f;
    private const float TurnDelay = 2f;
    private const float MinThinkTime = 1f;
    private const float MaxThinkTime = 5f;

    #endregion

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // �ٴ� ���̾� ����ũ�� ������
        floorLayerMask = LayerMask.GetMask("Ready_Floor");

        // Think �Լ��� 0.5�� ���� �� ȣ��
        Invoke("Think", ThinkDelay);
    }

    private void FixedUpdate()
    {
        // ĳ������ ���� �ӵ� ������Ʈ
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // ĳ������ ��������Ʈ ���� ����
        sprite.flipX = Mathf.Sign(nextMove) == -1;

        // ĳ������ ���� �̵� ������ �� ��ġ ���
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);

        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        // ray�� ���� �ٴ� ����
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 5, floorLayerMask);

        // �ٴ��� ���ٸ� Turn() �Լ� ȣ��
        if (rayHit.collider == null)
            Turn();
    }

    void Turn() //  ĳ���� ������ ��ȯ
    {
        nextMove *= -1;

        CancelInvoke();
        Invoke("Think", TurnDelay);
    }
    
    void Think()    // ĳ������ ���� �̵� ���� ����
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(MinThinkTime, MaxThinkTime);
        Invoke("Think", nextThinkTime);
    }

    void FadeOut()
    {
        StartCoroutine("FadeOutSprites");
    }

    // ĳ���� ���̵� �ƿ�
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
