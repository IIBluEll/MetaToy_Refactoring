using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Main_Title_Screen.cs
// 화면 터치시 준비 단계로 넘어감
// 텍스트 깜박임
// 화면 터치시, 페이드 아웃 적용

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
        // 메인 타이틀 화면 터치시 비활성화 & 다음 화면으로 전환
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase== TouchPhase.Began) 
            {
                // 타이틀 화면 페이드아웃 시작
                StartCoroutine("ImgFadeOut");
            }
        }
    }

    // "Touch To Play" 점멸 구현 코루틴
    IEnumerator TxtBlink()
    {
        while(true)
        {
            float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);   // MathF.PingPong을 이용하여 점멸 구현
            touchToPlay.color = new Color(touchToPlay.color.r, touchToPlay.color.g, touchToPlay.color.b, alpha);
            yield return null;
        }
    }

    // 타이틀 화면 페이드 아웃을 위한 코루틴
    IEnumerator ImgFadeOut()
    {
        StopCoroutine("TxtBlink");
        //텍스트 오브젝트 비활성화
        touchToPlay.gameObject.SetActive(false);

        float time = 0f;

        //... 타이틀 화면 페이드 아웃 시작과 끝 색상 지정
        Color startColor = Title_Img.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        //...

        // fadeSpeed 값 시간 동안 페이드 아웃 진행
        while (time < fadeSpeed)
        {
            time += Time.deltaTime;

            float t = time / fadeSpeed;

            // Lerp를 사용해, 시작 색상값에서 끝 색상값으로 서서히 변경
            Title_Img.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        Ready_IMG.SetActive(true);  // 레디 화면 이미지
        Playerble_CHAR.SetActive(true); // 레디 화면 캐릭터들
        this.gameObject.SetActive(false);   // 타이틀 화면 종료
    }
}
