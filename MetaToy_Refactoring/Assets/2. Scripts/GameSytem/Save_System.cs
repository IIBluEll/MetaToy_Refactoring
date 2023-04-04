using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Save_System.cs
// 게임 데이터 저장 및 불러오기

public class Save_System : MonoBehaviour
{
    #region *** Variable Declare ***
    
    public static Save_System instance; // 싱글톤 패턴

    public int level = 1; // 현재 스테이지 레벨
    public int isTitleSkip = 0; // 타이핑 화면 스킵 여부 
                                 // 0 => false / 1 = > true
    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGame(); // 게임이 시작되자마자 데이터 로드를 위함
    }

    // 데이터 저장
    public void SaveGame()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("isTitleSkip", isTitleSkip);
        PlayerPrefs.Save();
        Debug.Log($"데이터 저장 level : {level}");
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("level")&& PlayerPrefs.HasKey("isTitleSkip"))
        {
            level = PlayerPrefs.GetInt("level");
            isTitleSkip = PlayerPrefs.GetInt("isTitleSkip");
            Debug.Log($"데이터 불러옴 level : {level}");
            Debug.Log($"데이터 불러옴 isTitleSkip : {isTitleSkip}");
        }
        else
        {
            level = 4;
            isTitleSkip = 0;
            Debug.LogWarning("저장된 데이터가 없음");
        }    
    }
}
