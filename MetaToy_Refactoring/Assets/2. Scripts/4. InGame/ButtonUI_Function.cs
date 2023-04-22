using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI_Function : MonoBehaviour
{
    public GameObject loadingIMG;

    private void Start() 
    {
        Time.timeScale = 0; 
    }

    public void StartButton()
    {
        Time.timeScale = 1;

        this.gameObject.SetActive(false);
    }

    public void GoMainButton()
    {
        Save_System.instance.LevelUp();
        Time.timeScale = 1;

        loadingIMG.SetActive(true);
        Save_System.instance.LoadSceneManager("ChoiceCharacter");
    }
}
