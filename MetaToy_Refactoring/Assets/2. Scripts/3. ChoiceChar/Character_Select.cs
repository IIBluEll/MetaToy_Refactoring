using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Character_Select.cs
// 1. 좌우 버튼을 클릭시 캐릭터 스프라이트가 순서에 맞게 변경
// 2. 동시에 캐릭터 설명 이미지도 바뀜
// 3. 선택할 수 없는 캐릭터일 경우, 스타트 버튼 비활성화

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
    [Header(" [ UI Objects ] ")]
    // UI 상호작용을 위함
    public Button gamePlay_Btn;
    public GameObject stage_Select;

    public GameObject loading_IMG;

    // 캐릭터 스프라이트 배열중 현재 인덱스 값을 위한 변수
    private int currentIndex = 0;

    private void Start()
    {
        // 초기 캐릭터 이미지 설정
        characterImage.sprite = characterSprites[currentIndex];
        // 초기 캐릭터 설명 이미지 설정
        characterExplaneImg.sprite = characterExplan[currentIndex];
    }

    //! -----버튼 함수---------

    public void NextCharacter() // 오른쪽 버튼 => 다음 캐릭터 이미지
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

    public void PreviousCharacter() // 왼쪽 버튼 => 직전 캐릭터 이미지 
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

    public void StartInGame()  // Start 버튼 => 스테이지 선택 UI 활성화
    {
        stage_Select.SetActive(true);

        // 플레이어가 선택한 캐릭터 인덱스를 Save시스템을 이용해, 인게임 씬으로 정보를 넘김
        Save_System.instance.Save_Character(currentIndex);
    }

    public void GoInGame()
    {
        stage_Select.SetActive(false);
        loading_IMG.SetActive(true);
        Save_System.instance.LoadSceneManager("Stage");
    }

    // 선택 가능한 플레이어블 캐릭터인지 확인
    // 아닐 경우 버튼 상호작용 제한
    public void CheckISPlayable()
    {      
        int nowLevel = Save_System.instance.level;

        // 플레이어가 선택한 캐릭터 인덱스가 진행한 레벨보다 낮다면 비활성화
        gamePlay_Btn.interactable = currentIndex > nowLevel ? false : true;
  
    }
}
