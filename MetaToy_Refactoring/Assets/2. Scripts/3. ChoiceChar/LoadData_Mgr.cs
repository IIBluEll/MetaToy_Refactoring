using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// LoadData_Mgr.cs
// 1. �� ����� ����Ǿ� �ִ� �÷��̾� �����Ȳ�� �ε��� 
// 2. �����Ȳ�� ���� �� UI�� ��������Ʈ ����
// { ĳ���� �̹��� / �հ����� �̹��� }

public class LoadData_Mgr : MonoBehaviour
{
    [Header(" [ # For Change Character Sprite ] ")]
    public Character_Select _script_Character_Select;  // ĳ���� ���� ��ũ��Ʈ�� ��������Ʈ �迭�� ���� ����
    public List<Sprite> willChangeChar_IMG; // ������ ĳ���� ��������Ʈ ����Ʈ

    [Space(20f)]
    [Header(" [ # For Change Crown Sprite ] ")]
    
    public List<Image> currentCrown_IMG;    // ���� �հ� ��������Ʈ ����Ʈ
    public List<Sprite> willChangeCrown_IMG;    // ������ �հ� ��������Ʈ ����Ʈ

    [Space(20f)]
    [Header(" [ # For Change Ticket GameObject] ")]
    public GameObject currentTicket_GameObject; // ���� Ƽ�� ���� ������Ʈ
    public GameObject full_Ticket_GameObject;   // Ǯ ������ Ƽ�� ���� ������Ʈ

    [Space(20f)]
    [Header("[ BackGround Image Array ]")]
    public Sprite[] backGround_IMG;
    public Image current_BackGround;

    private void Awake()
    {
        int nowLevel = Save_System.instance.level;
        bool isLastClear = Save_System.instance.lastStageClear == 1 ? true : false;

        current_BackGround.sprite = backGround_IMG[nowLevel];

        if ( nowLevel > 0)
        {
            for (int i = 1; i <= nowLevel; i++)
            {
                // ĳ���� ��������Ʈ �ٲٱ�
                _script_Character_Select.characterSprites[i] = willChangeChar_IMG[i -1];

                // �հ� ��������Ʈ �ٲٱ�
                currentCrown_IMG[i-1].sprite = willChangeCrown_IMG[i-1];
            }
        }
        
        if(isLastClear)
        {
            currentTicket_GameObject.SetActive(false);
        }
    }

    // Ƽ�� ���� ��ư Ŭ���� Ǯ ������ Ƽ�� ������Ʈ
    public void FullSize_Ticket()
    {
        full_Ticket_GameObject.SetActive(true);
    }


}
