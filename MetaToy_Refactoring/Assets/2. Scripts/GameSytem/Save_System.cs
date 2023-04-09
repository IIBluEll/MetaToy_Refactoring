using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Save_System.cs
// ���� ������ ���� �� �ҷ�����

public class Save_System : MonoBehaviour
{
    #region *** Variable Declare ***
    
    public static Save_System instance; // �̱��� ����

    public int level = 0; // ���� �������� ����
    public int lastStageOpen = 0; // ������ �������� ���� ����
                                  // 0 -> false / 1 -> true
    public int lastStageClear = 0; // ...
    public int isTitleSkip = 0; // Ÿ���� ȭ�� ��ŵ ���� 
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

        LoadGame(); // ������ ���۵��ڸ��� ������ �ε带 ����
        MakeTicketRanNum(); // NFT ��ȣ ����
    }

    // ������ ����
    public void SaveGame()
    {
        
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("isTitleSkip", isTitleSkip);
        PlayerPrefs.SetInt("lastStageOpen", lastStageOpen);
        PlayerPrefs.SetString("nft_Number", nft_Number);
        PlayerPrefs.Save();
        Debug.Log($"������ ���� level : {level}");
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("level")&& PlayerPrefs.HasKey("isTitleSkip"))
        {
            level = PlayerPrefs.GetInt("level");
            isTitleSkip = PlayerPrefs.GetInt("isTitleSkip");
            lastStageOpen = PlayerPrefs.GetInt("lastStageOpen");
            nft_Number = PlayerPrefs.GetString("nft_Number");
            
            Debug.Log($"������ �ҷ��� level : {level}");
            Debug.Log($"������ �ҷ��� isTitleSkip : {isTitleSkip}");
            Debug.Log($"������ �ҷ��� lastStageOpen : {lastStageOpen}");
            Debug.Log($"������ �ҷ��� nft_Number : {nft_Number}");

        }
        else
        {
            level = 0;
            isTitleSkip = 0;
            lastStageOpen = 0;
            Debug.LogWarning("����� �����Ͱ� ����");
        }    
    }

    // �������� Ŭ����� ������
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

    // ���� NFT 16�ڸ� ��ȣ ������
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
