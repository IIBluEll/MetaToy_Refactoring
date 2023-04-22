using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Main_Ready_Screen.cs
// 타이틀 이후 화면, 플레이어블 캐릭터 돌아다님
// 플레이어의 진행도에 따른 배경화면 바뀜

public class Main_Ready_Screen : MonoBehaviour
{
  #region *** Variable Declare ***

  [Header("[ Ready_Backgrounds_IMG ]")]
  public Sprite[] ready_BackGround;   // 레디화면의 배경화면 배열

  [Space(20f)]
  [Header("[ View_Story_Alarm ]")]
  public GameObject Alarm_ViewStroy;  // 스토리 스킵 여부 버튼

  [Space(20f)]
  [Header("[ ReadyScreen_Objects_ToFadeOut ]")]
  public GameObject[] targets;        // 캐릭터들 페이드 아웃

  [Space(20f)]
  [Header("[ Loading_IMG ]")]
  public GameObject loading_IMG;  // 로딩 이미지

  [Space(20f)]
  [Header("[ Save_System_Data ]")]
  [SerializeField] int data_Level;
  [SerializeField] bool data_isSkipStory;

  Image ready_IMG;


  #endregion

  private void Awake()
  {
    ready_IMG = GetComponent<Image>();
  }

  private void Start()
  {
    data_Level = Save_System.instance.level;
    data_isSkipStory = Save_System.instance.isTitleSkip == 0 ? false : true;

    //현재 레벨에 따라 배경화면 바꾸기
    ready_IMG.sprite = ready_BackGround[data_Level];
  }

  // ----- 버튼 함수들 ----- //

  public void PlayBtn()
  {
    if (data_isSkipStory == false)
      Alarm_ViewStroy.SetActive(true);
    else
      StartCoroutine("GoCharChoiceScene");
  }

  public void YesBtn()
  {
    Save_System.instance.isTitleSkip = 1;

    Alarm_ViewStroy.SetActive(false);

    // 캐릭터 선택 씬으로 이동
    StartCoroutine("GoCharChoiceScene");
  }

  public void NoBtn()
  {
    Alarm_ViewStroy.SetActive(false);
    // 타이핑 씬으로 이동
    StartCoroutine("GoTypingStoryScnene");
  }

  // 캐릭터 선택 씬으로 이동
  IEnumerator GoCharChoiceScene()
  {
    foreach (var item in targets)
    {
      // SendMessage로 캐릭터들 페이드 아웃 호출
      item.SendMessage("FadeOut", SendMessageOptions.DontRequireReceiver);
    }
    yield return new WaitForSeconds(.5f);

    loading_IMG.SetActive(true);

    Save_System.instance.LoadSceneManager("ChoiceCharacter");
  }

  // 스토리 타이밍 씬으로 이동
  IEnumerator GoTypingStoryScnene()
  {
    foreach (var item in targets)
    {
      // SendMessage로 캐릭터들 페이드 아웃 호출
      item.SendMessage("FadeOut", SendMessageOptions.DontRequireReceiver);
    }
    yield return new WaitForSeconds(.25f);

    loading_IMG.SetActive(true);

    Save_System.instance.LoadSceneManager("Stroy_Typing");
  }


}
