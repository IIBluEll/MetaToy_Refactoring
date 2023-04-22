using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_UI : MonoBehaviour
{
  // 조이스틱 비활성화
  public GameObject Joystick;

  public GameObject pausePannel;

  public GameObject pauseBtns;
public GameObject loadingIMG;
  public Button pausebtn;

  bool isPaused = false;

  public void TogglePaused()
  {
    isPaused = !isPaused;
    pausebtn.interactable = !pausebtn.interactable;
    Time.timeScale = isPaused == false ? 1 : 0;

  }

  // 일시정지 버튼을 눌렀을 때
  public void ClickPausedBtn()
  {
    Joystick.SetActive(false);
    pausePannel.SetActive(true);
    pauseBtns.SetActive(true);

    TogglePaused();
  }

  // 게임 재개 버튼
  public void ResumeGame()
  {
    TogglePaused();

    Joystick.SetActive(true);
    pausePannel.SetActive(false);
    pauseBtns.SetActive(false);
  }

  // 나가기 버튼
  public void ExitGame()
  {
    TogglePaused();

    loadingIMG.SetActive(true);
        Save_System.instance.LoadSceneManager("ChoiceCharacter");
    
  }
}
