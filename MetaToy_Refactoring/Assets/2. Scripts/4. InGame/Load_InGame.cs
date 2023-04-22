using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_InGame : MonoBehaviour
{
   public Sprite[] backgrounds_Img; // 배경화면 스프라이드 배열
   public Sprite[] character_Img; // 플레이어 캐릭터 스프라이트 배열

   public Sprite[] endUI_Img; // 스테이지 종료 UI 이미지

   public SpriteRenderer background;
   public SpriteRenderer player;
   public Image endUI;

   int level; // 플레이어가 진행한 스테이지 수

   private void Awake()
   {
        level = Save_System.instance.level; 
        background.sprite = backgrounds_Img[level];
        endUI.sprite = endUI_Img[level];

        player.sprite = character_Img[Save_System.instance.Load_Character()];
   }

}
