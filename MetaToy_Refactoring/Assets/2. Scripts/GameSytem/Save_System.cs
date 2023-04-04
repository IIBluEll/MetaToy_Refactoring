using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Save_System.cs
// ���� ������ ���� �� �ҷ�����

public class Save_System : MonoBehaviour
{
    #region *** Variable Declare ***
    
    public static Save_System instance; // �̱��� ����

    public int level = 1; // ���� �������� ����
    public int isTitleSkip = 0; // Ÿ���� ȭ�� ��ŵ ���� 
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

        LoadGame(); // ������ ���۵��ڸ��� ������ �ε带 ����
    }

    // ������ ����
    public void SaveGame()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("isTitleSkip", isTitleSkip);
        PlayerPrefs.Save();
        Debug.Log($"������ ���� level : {level}");
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("level")&& PlayerPrefs.HasKey("isTitleSkip"))
        {
            level = PlayerPrefs.GetInt("level");
            isTitleSkip = PlayerPrefs.GetInt("isTitleSkip");
            Debug.Log($"������ �ҷ��� level : {level}");
            Debug.Log($"������ �ҷ��� isTitleSkip : {isTitleSkip}");
        }
        else
        {
            level = 4;
            isTitleSkip = 0;
            Debug.LogWarning("����� �����Ͱ� ����");
        }    
    }
}
