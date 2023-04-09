using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//? Select_Stage.cs
//? 1. 플레이어의 진행상황을 체크하고 갈 수 있는 스테이지를 확인함
//? 2. 플레이 불가능한 스테이지 버튼을 비활성화함

public class Select_Stage : MonoBehaviour
{
    public List<Button> stage_Buttons;

    private void Awake() 
    {
        int level = Save_System.instance.level;

       for(int i = 0; i < level + 1; i++)
       {
            stage_Buttons[i].interactable = true;
       }
    }
}
