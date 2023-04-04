using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Main_Title_Screen.cs
// ȭ�� ��ġ�� �غ� �ܰ�� �Ѿ
// �ؽ�Ʈ ������
// ȭ�� ��ġ��, ���̵� �ƿ� ����

public class Main_Title_Screen : MonoBehaviour
{
    #region *** Variable Declare ***

    [Header("[ Text Blink Speed Value ]")]
    public float blinkSpeed = 1f;

    [Header("[ Title Fade Out Time ]")]
    public float fadeSpeed = 1f;

    [Space(10f)]
    [Header("[ Touch To Start Txt ]")]
    public Text touchToPlay;

    [Space(10f)]
    [Header("[ Ready_Screen ]")]
    public GameObject Ready_IMG;
    public GameObject Playerble_CHAR;

    public Image Title_Img;

    #endregion

    private void Start()
    {
        touchToPlay= GetComponentInChildren<Text>();

        StartCoroutine("TxtBlink");
    }

    private void Update()
    {   
        // ���� Ÿ��Ʋ ȭ�� ��ġ�� ��Ȱ��ȭ & ���� ȭ������ ��ȯ
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase== TouchPhase.Began) 
            {
                // Ÿ��Ʋ ȭ�� ���̵�ƿ� ����
                StartCoroutine("ImgFadeOut");
            }
        }
    }

    // "Touch To Play" ���� ���� �ڷ�ƾ
    IEnumerator TxtBlink()
    {
        while(true)
        {
            float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);   // MathF.PingPong�� �̿��Ͽ� ���� ����
            touchToPlay.color = new Color(touchToPlay.color.r, touchToPlay.color.g, touchToPlay.color.b, alpha);
            yield return null;
        }
    }

    // Ÿ��Ʋ ȭ�� ���̵� �ƿ��� ���� �ڷ�ƾ
    IEnumerator ImgFadeOut()
    {
        StopCoroutine("TxtBlink");
        //�ؽ�Ʈ ������Ʈ ��Ȱ��ȭ
        touchToPlay.gameObject.SetActive(false);

        float time = 0f;

        //... Ÿ��Ʋ ȭ�� ���̵� �ƿ� ���۰� �� ���� ����
        Color startColor = Title_Img.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        //...

        // fadeSpeed �� �ð� ���� ���̵� �ƿ� ����
        while (time < fadeSpeed)
        {
            time += Time.deltaTime;

            float t = time / fadeSpeed;

            // Lerp�� �����, ���� ���󰪿��� �� �������� ������ ����
            Title_Img.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        Ready_IMG.SetActive(true);  // ���� ȭ�� �̹���
        Playerble_CHAR.SetActive(true); // ���� ȭ�� ĳ���͵�
        this.gameObject.SetActive(false);   // Ÿ��Ʋ ȭ�� ����
    }
}
