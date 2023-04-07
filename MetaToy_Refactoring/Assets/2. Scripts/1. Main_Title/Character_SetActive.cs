using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character_SetActive.cs
// 1. ���� ȭ���� ����� ��, ���� ������ �°� ĳ���Ͱ� �����ϰԲ� ��

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
