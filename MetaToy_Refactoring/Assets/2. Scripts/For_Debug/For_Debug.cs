using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class For_Debug : MonoBehaviour
{
  public InputField inputNum;
  public int stageNum;
  public bool isLastStageClear = false;


    public Text updateTxt;
  private void Update()
  {
    isLastStageClear = Save_System.instance.lastStageClear == 0 ? false : true;

    updateTxt.text = $"Level : {stageNum} // LastStageClear? : {isLastStageClear}";
  }


  public void CheckNum()
  {
    InputName();
    Debug.Log("인풋!");
  }
  public void InputName()
  {
    stageNum = int.Parse(inputNum.GetComponent<InputField>().text);
    Save_System.instance.level = stageNum;
  }

  public void LastStageClear()
  {
    Save_System.instance.lastStageClear = 1;
  }

  public void StartGame()
  {
    SceneManager.LoadScene("Main_Title");
  }

}
