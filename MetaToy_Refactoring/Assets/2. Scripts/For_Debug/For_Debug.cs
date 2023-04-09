using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class For_Debug : MonoBehaviour
{
    public InputField inputNum;
    public int stageNum;

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

    public void StartGame()
    {
        SceneManager.LoadScene("Main_Title");
    }

}
