using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Save_System.cs
// 게임 데이터 저장 및 불러오기

public class Save_System : MonoBehaviour
{
    #region *** Variable Declare ***
    
    public static Save_System instance; // 싱글톤 패턴

    public int level = 0; // 현재 스테이지 레벨
    public int lastStageOpen = 0; // 마지막 스테이지 개방 여부
                                  // 0 -> false / 1 -> true
    public int lastStageClear = 0; // ...
    public int isTitleSkip = 0; // 타이핑 화면 스킵 여부 
                                // 0 => false / 1 = > true

    public string nft_Number = "";
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
        MakeTicketRanNum(); // NFT 번호 생성
    }

    // 데이터 저장
    public void SaveGame()
    {
        
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("isTitleSkip", isTitleSkip);
        PlayerPrefs.SetInt("lastStageOpen", lastStageOpen);
        PlayerPrefs.SetString("nft_Number", nft_Number);
        PlayerPrefs.Save();
        Debug.Log($"데이터 저장 level : {level}");
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("level")&& PlayerPrefs.HasKey("isTitleSkip"))
        {
            level = PlayerPrefs.GetInt("level");
            isTitleSkip = PlayerPrefs.GetInt("isTitleSkip");
            lastStageOpen = PlayerPrefs.GetInt("lastStageOpen");
            nft_Number = PlayerPrefs.GetString("nft_Number");
            
            Debug.Log($"데이터 불러옴 level : {level}");
            Debug.Log($"데이터 불러옴 isTitleSkip : {isTitleSkip}");
            Debug.Log($"데이터 불러옴 lastStageOpen : {lastStageOpen}");
            Debug.Log($"데이터 불러옴 nft_Number : {nft_Number}");

        }
        else
        {
            level = 0;
            isTitleSkip = 0;
            lastStageOpen = 0;
            Debug.LogWarning("저장된 데이터가 없음");
        }    
    }

    // 스테이지 클리어시 레벨업
    public void LevelUp()
    {
        if (level < 4)
        {
            level++;
        }
        else if(level == 4)
        {
            lastStageOpen = 1;
        }
            
        SaveGame();
    }

    // 랜덤 NFT 16자리 번호 생성기
    public void MakeTicketRanNum()
    {
        for (int i = 0; i < 16; i++)
        {
            int[] a = new int[16];
            a[i] = Random.Range(0, 10);

            nft_Number += $"{a[i]}";
        }

    }

    public void Save_Character()
    {

    }

    public void Load_Character()
    {
        
    }
}
