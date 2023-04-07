using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Full_Ticket_UI : MonoBehaviour
{
    public TextMeshProUGUI number_Txt;

    private void Awake()
    {
        number_Txt.text = "";

        if(string.IsNullOrEmpty(Save_System.instance.nft_Number))
        {
            number_Txt.text = "Error";
        }
        else
        {
            number_Txt.text = Save_System.instance.nft_Number;
        }
    }

    private void Update()
    {
        // 터치시 스스로 비활성화
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}

