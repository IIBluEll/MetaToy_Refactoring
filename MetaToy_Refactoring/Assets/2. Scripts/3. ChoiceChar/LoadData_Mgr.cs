using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// LoadData_Mgr.cs
// 1. 씬 실행시 저장되어 있는 플레이어 진행상황을 로드함 
// 2. 진행상황에 맞춰 각 UI들 스프라이트 변경
// { 캐릭터 이미지 / 왕관조각 이미지 }

public class LoadData_Mgr : MonoBehaviour
{
    [Header(" [ # For Change Character Sprite ] ")]
    public Character_Select _script_Character_Select;  // 캐릭터 변경 스크립트의 스프라이트 배열을 쓰기 위함
    public List<Sprite> willChangeChar_IMG; // 변경할 캐릭터 스프라이트 리스트

    [Space(20f)]
    [Header(" [ # For Change Crown Sprite ] ")]
    
    public List<Image> currentCrown_IMG;    // 현재 왕관 스프라이트 리스트
    public List<Sprite> willChangeCrown_IMG;    // 변경할 왕관 스프라이트 리스트

    [Space(20f)]
    [Header(" [ # For Change Ticket GameObject] ")]
    public GameObject currentTicket_GameObject; // 현재 티켓 게임 오브젝트
    public GameObject full_Ticket_GameObject;   // 풀 사이즈 티켓 게임 오브젝트

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
                // 캐릭터 스프라이트 바꾸기
                _script_Character_Select.characterSprites[i] = willChangeChar_IMG[i -1];

                // 왕관 스프라이트 바꾸기
                currentCrown_IMG[i-1].sprite = willChangeCrown_IMG[i-1];
            }
        }
        
        if(isLastClear)
        {
            currentTicket_GameObject.SetActive(false);
        }
    }

    // 티켓 오픈 버튼 클릭시 풀 사이즈 티켓 오브젝트
    public void FullSize_Ticket()
    {
        full_Ticket_GameObject.SetActive(true);
    }


}
