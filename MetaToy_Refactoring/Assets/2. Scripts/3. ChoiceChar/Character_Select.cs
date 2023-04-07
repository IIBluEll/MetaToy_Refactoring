using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Character_Select.cs
// 1. �¿� ��ư�� Ŭ���� ĳ���� ��������Ʈ�� ������ �°� ����
// 2. ���ÿ� ĳ���� ���� �̹����� �ٲ�

public class Character_Select : MonoBehaviour
{
    [Header(" [ Character Sprites ] ")]
    // ĳ���� �̹��� ��������Ʈ ����Ʈ
    public List<Sprite> characterSprites;

    [Space(20f)]
    [Header(" [ Character Explan IMG ] ")]
    // ĳ���� ���� ��������Ʈ ����Ʈ
    public List<Sprite> characterExplan;

    [Space(20f)]
    // ���� ĳ���� �̹���
    public Image characterImage;

    public Image characterExplaneImg;

    [Space(20f)]
    [Header(" [ GamePlay Button ] ")]
    // ĳ���� ���� ��������Ʈ ����Ʈ
    public Button gamePlay_Btn;

    // ĳ���� ��������Ʈ �迭�� ���� �ε��� ���� ���� ����
    private int currentIndex = 0;

    private void Start()
    {
        // �ʱ� ĳ���� �̹��� ����
        characterImage.sprite = characterSprites[currentIndex];
        // �ʱ� ĳ���� ���� �̹��� ����
        characterExplaneImg.sprite = characterExplan[currentIndex];
    }

    public void NextCharacter()
    {
        currentIndex++;

        if(currentIndex >= characterSprites.Count)
        {
            // �ε������� ����Ʈ ũ�⸦ ������ 0�� ��
            currentIndex = 0;
        }
        // ĳ���� �̹����� ����
        characterImage.sprite = characterSprites[currentIndex];
        // ĳ���� ���� �̹��� ����
        characterExplaneImg.sprite = characterExplan[currentIndex];

        CheckISPlayable();
    }

    public void PreviousCharacter()
    {
        currentIndex--;

        if(currentIndex < 0)
        {
            // �ε��� ���� 0 �̸��̸� ����Ʈ ������ ���ư� 
            currentIndex = characterSprites.Count - 1;
        }
        // ĳ���� �̹����� ����
        characterImage.sprite = characterSprites[currentIndex];
        // ĳ���� ���� �̹��� ����
        characterExplaneImg.sprite = characterExplan[currentIndex];

        CheckISPlayable();
    }

    // ���� ������ �÷��̾�� ĳ�������� Ȯ��
    // �ƴ� ��� ��ư ��ȣ�ۿ� ����
    public void CheckISPlayable()
    {
        int nowLevel = Save_System.instance.level;

        gamePlay_Btn.interactable = currentIndex > nowLevel ? false : true;
  
    }
}
