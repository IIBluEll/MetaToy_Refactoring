using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Character_Select.cs
// 1. 좌우 버튼을 클릭시 캐릭터 스프라이트가 순서에 맞게 변경
// 2. 동시에 캐릭터 설명 이미지도 바뀜

public class Character_Select : MonoBehaviour
{
    [Header(" [ Character Sprites ] ")]
    // 캐릭터 이미지 스프라이트 리스트
    public List<Sprite> characterSprites;

    [Space(20f)]
    [Header(" [ Character Explan IMG ] ")]
    // 캐릭터 설명 스프라이트 리스트
    public List<Sprite> characterExplan;

    [Space(20f)]
    // 현재 캐릭터 이미지
    public Image characterImage;

    public Image characterExplaneImg;

    [Space(20f)]
    [Header(" [ GamePlay Button ] ")]
    // 캐릭터 설명 스프라이트 리스트
    public Button gamePlay_Btn;

    // 캐릭터 스프라이트 배열중 현재 인덱스 값을 위한 변수
    private int currentIndex = 0;

    private void Start()
    {
        // 초기 캐릭터 이미지 설정
        characterImage.sprite = characterSprites[currentIndex];
        // 초기 캐릭터 설명 이미지 설정
        characterExplaneImg.sprite = characterExplan[currentIndex];
    }

    public void NextCharacter()
    {
        currentIndex++;

        if(currentIndex >= characterSprites.Count)
        {
            // 인덱스값이 리스트 크기를 넘으면 0이 됨
            currentIndex = 0;
        }
        // 캐릭터 이미지값 변경
        characterImage.sprite = characterSprites[currentIndex];
        // 캐릭터 설명 이미지 변경
        characterExplaneImg.sprite = characterExplan[currentIndex];

        CheckISPlayable();
    }

    public void PreviousCharacter()
    {
        currentIndex--;

        if(currentIndex < 0)
        {
            // 인덱스 값이 0 미만이면 리스트 끝으로 돌아감 
            currentIndex = characterSprites.Count - 1;
        }
        // 캐릭터 이미지값 변경
        characterImage.sprite = characterSprites[currentIndex];
        // 캐릭터 설명 이미지 변경
        characterExplaneImg.sprite = characterExplan[currentIndex];

        CheckISPlayable();
    }

    // 선택 가능한 플레이어블 캐릭터인지 확인
    // 아닐 경우 버튼 상호작용 제한
    public void CheckISPlayable()
    {
        int nowLevel = Save_System.instance.level;

        gamePlay_Btn.interactable = currentIndex > nowLevel ? false : true;
  
    }
}
