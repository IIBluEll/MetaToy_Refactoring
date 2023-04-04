using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Main_Ready_Screen.cs
// Ÿ��Ʋ ���� ȭ��, �÷��̾�� ĳ���� ���ƴٴ�
// �÷��̾��� ���൵�� ���� ���ȭ�� �ٲ�

public class Main_Ready_Screen : MonoBehaviour
{
    #region *** Variable Declare ***

    [Header("[ Ready_Backgrounds_IMG ]")]
    public Sprite[] ready_BackGround;   // ����ȭ���� ���ȭ�� �迭

    [Space(20f)]
    [Header("[ View_Story_Alarm ]")]
    public GameObject Alarm_ViewStroy;  // ���丮 ��ŵ ���� ��ư

    [Space(20f)]
    [Header("[ ReadyScreen_Objects_ToFadeOut ]")]
    public GameObject[] targets;        // ĳ���͵� ���̵� �ƿ�

    [Space(20f)]
    [Header("[ Loading_IMG ]")]
    public GameObject loading_IMG;  // �ε� �̹���

    [Space(20f)]
    [Header("[ Save_System_Data ]")]
    [SerializeField] int data_Level;
    [SerializeField] bool data_isSkipStory;

    Image ready_IMG;

    float duration = 1.0f; // ���̵� �ƿ� �ð�

    #endregion

    private void Awake()
    {
        ready_IMG = GetComponent<Image>();
    }

    private void Start()
    {
        data_Level = Save_System.instance.level;
        data_isSkipStory = Save_System.instance.isTitleSkip == 0 ? false : true;

        //���� ������ ���� ���ȭ�� �ٲٱ�
        ready_IMG.sprite = ready_BackGround[data_Level];
    }

    // ----- ��ư �Լ��� ----- //

    public void PlayBtn()
    {
        if(data_isSkipStory == false)
            Alarm_ViewStroy.SetActive(true);
    }

    public void YesBtn()
    {
        Save_System.instance.isTitleSkip = 1;

        // ĳ���� ���� ������ �̵�
        StartCoroutine("GoCharChoiceScene");
    }

    public void NoBtn()
    {
        // Ÿ���� ������ �̵�
        StartCoroutine("GoTypingStoryScnene");
    }

    // ĳ���� ���� ������ �̵�
    IEnumerator GoCharChoiceScene() 
    {
        foreach (var item in targets)
        {
            // SendMessage�� ĳ���͵� ���̵� �ƿ� ȣ��
            item.SendMessage("FadeOut", SendMessageOptions.DontRequireReceiver);
        }
        yield return new WaitForSeconds(.5f);

        loading_IMG.SetActive(true);

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene("CharChoice");
    }

    // ���丮 Ÿ�̹� ������ �̵�
    IEnumerator GoTypingStoryScnene()
    {
        foreach (var item in targets)
        {
            // SendMessage�� ĳ���͵� ���̵� �ƿ� ȣ��
            item.SendMessage("FadeOut", SendMessageOptions.DontRequireReceiver);
        }
        yield return new WaitForSeconds(.5f);

        loading_IMG.SetActive(true);

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene("Stroy_Typing");
    }


}