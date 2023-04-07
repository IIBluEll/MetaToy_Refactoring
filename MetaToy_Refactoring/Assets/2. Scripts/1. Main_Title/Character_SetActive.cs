using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character_SetActive.cs
// 1. 레디 화면이 실행될 때, 현재 레벨에 맞게 캐릭터가 등장하게끔 함

public class Character_SetActive : MonoBehaviour
{
    #region *** Variable Declare ***

    [Header("[ Characters List ]")]
    public GameObject[] Characters;

    #endregion

    private void Awake()
    {
        for (int i = 0; i <= Save_System.instance.level; i++)
            Characters[i].SetActive(true);
    }
}
