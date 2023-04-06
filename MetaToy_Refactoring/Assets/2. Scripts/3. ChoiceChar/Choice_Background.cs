using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice_Background : MonoBehaviour
{
    [Header("[ BackGround Image Array ]")]
    public Sprite[] backGround_IMG;

    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();

        img.sprite = backGround_IMG[Save_System.instance.level];
    }
}
