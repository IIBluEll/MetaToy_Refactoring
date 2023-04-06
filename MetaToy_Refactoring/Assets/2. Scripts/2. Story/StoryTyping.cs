using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

// StoryTyping.cs
// 1. ���丮�� Ÿ���� �ϴ� �ð����� ȿ��
// 2. StoryData ��ũ���ͺ� ������Ʈ�� �̿��� �پ��� ���丮�� ���� ���氡��

public class StoryTyping : MonoBehaviour
{
    [Header("[ Story Data List ]")]
    // ���丮 �����͸� �����ϴ� StoryData Ŭ������ �迭
    public StoryData[] datas;

    [Space(20f)]
    [Header("[ TMP TXT ]")]
    public TextMeshProUGUI storyTxt;    // ���� ���丮 ��ư

    [Space(20f)]
    [Header("[ Loading Screen IMG ]")]
    public GameObject loadingIMG;

    [Space(20f)]
    [Header("[ Next Story Button ]")]
    public Button nextStoryBtn;

    string storyMessage;    // ���� ���丮
    string temp_StoryMessage;   // Ÿ���� ȿ���� ���� ���ڿ�

    int check_View_Count = 0;   // ���� ������ �ε���
    float typing_Speed = 0f;    // Ÿ���� �ӵ�

    private void Start()
    {
        // ���� ���丮 ��ư ��Ȱ��ȭ
        nextStoryBtn.interactable = false;

        storyTxt.text = ""; // �ؽ�Ʈ �ʱ�ȭ

        storyMessage = datas[check_View_Count].story;
        typing_Speed = datas[check_View_Count].typingSpeed;

        StartCoroutine("TypingAction");
    }

    IEnumerator TypingAction()
    {
        for(int i = 0; i < storyMessage.Length; i++)
        {
            yield return new WaitForSeconds(typing_Speed);

            // ���� �ܰ迡�� ǥ�õ� �޽����� ������
            temp_StoryMessage += storyMessage.Substring(0, i);
            storyTxt.text = temp_StoryMessage;
            temp_StoryMessage = "";
        }
        // ���� ���丮 ��ư Ȱ��ȭ
        nextStoryBtn.interactable = true;
    }

    // ĳ���� ���� ������ �̵�
    IEnumerator GoCharChoiceScene()
    {
        loadingIMG.SetActive(true);

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene("ChoiceCharacter");
    }

    // ���丮 Ÿ������ ������ ���, ���� ���丮 ����
    // ���丮�� ������ ��� ĳ���� ���� ȭ������ ��ȯ
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

        else // ĳ���� ����ȭ�� �� ��ȯ
            StartCoroutine("GoCharChoiceScene");
        
    }
}
