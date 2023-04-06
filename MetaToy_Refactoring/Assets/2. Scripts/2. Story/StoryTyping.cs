using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

// StoryTyping.cs
// 1. 스토리를 타이핑 하는 시각적인 효과
// 2. StoryData 스크립터블 오브젝트를 이용해 다양한 스토리를 쉽게 변경가능

public class StoryTyping : MonoBehaviour
{
    [Header("[ Story Data List ]")]
    // 스토리 데이터를 저장하는 StoryData 클래스의 배열
    public StoryData[] datas;

    [Space(20f)]
    [Header("[ TMP TXT ]")]
    public TextMeshProUGUI storyTxt;    // 다음 스토리 버튼

    [Space(20f)]
    [Header("[ Loading Screen IMG ]")]
    public GameObject loadingIMG;

    [Space(20f)]
    [Header("[ Next Story Button ]")]
    public Button nextStoryBtn;

    string storyMessage;    // 현재 스토리
    string temp_StoryMessage;   // 타이핑 효과를 위한 문자열

    int check_View_Count = 0;   // 현재 데이터 인덱스
    float typing_Speed = 0f;    // 타이핑 속도

    private void Start()
    {
        // 다음 스토리 버튼 비활성화
        nextStoryBtn.interactable = false;

        storyTxt.text = ""; // 텍스트 초기화

        storyMessage = datas[check_View_Count].story;
        typing_Speed = datas[check_View_Count].typingSpeed;

        StartCoroutine("TypingAction");
    }

    IEnumerator TypingAction()
    {
        for(int i = 0; i < storyMessage.Length; i++)
        {
            yield return new WaitForSeconds(typing_Speed);

            // 현재 단계에서 표시될 메시지를 가져옴
            temp_StoryMessage += storyMessage.Substring(0, i);
            storyTxt.text = temp_StoryMessage;
            temp_StoryMessage = "";
        }
        // 다음 스토리 버튼 활성화
        nextStoryBtn.interactable = true;
    }

    // 캐릭터 선택 씬으로 이동
    IEnumerator GoCharChoiceScene()
    {
        loadingIMG.SetActive(true);

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene("ChoiceCharacter");
    }

    // 스토리 타이핑이 끝났을 경우, 다음 스토리 진행
    // 스토리가 끝났을 경우 캐릭터 선택 화면으로 전환
    public void NextStory_Btn()
    {
        if (check_View_Count < datas.Length -1)
        {
            check_View_Count++;
            storyMessage = datas[check_View_Count].story;
            typing_Speed = datas[check_View_Count].typingSpeed;

            nextStoryBtn.interactable = false;

            StartCoroutine("TypingAction");
        }

        else // 캐릭터 선택화면 씬 전환
            StartCoroutine("GoCharChoiceScene");
        
    }
}
