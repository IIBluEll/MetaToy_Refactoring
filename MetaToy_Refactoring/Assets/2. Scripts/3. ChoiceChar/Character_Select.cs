using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Character_Select.cs
// 1. �¿� ��ư�� Ŭ���� ĳ���� ��������Ʈ�� ������ �°� ����
// 2. ���ÿ� ĳ���� ���� �̹����� �ٲ�
// 3. ������ �� ���� ĳ������ ���, ��ŸƮ ��ư ��Ȱ��ȭ

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
    [Header(" [ UI Objects ] ")]
    // UI ��ȣ�ۿ��� ����
    public Button gamePlay_Btn;
    public GameObject stage_Select;

    public GameObject loading_IMG;

    // ĳ���� ��������Ʈ �迭�� ���� �ε��� ���� ���� ����
    private int currentIndex = 0;

    private void Start()
    {
        // �ʱ� ĳ���� �̹��� ����
        characterImage.sprite = characterSprites[currentIndex];
        // �ʱ� ĳ���� ���� �̹��� ����
        characterExplaneImg.sprite = characterExplan[currentIndex];
    }

    //! -----��ư �Լ�---------

    public void NextCharacter() // ������ ��ư => ���� ĳ���� �̹���
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

    public void PreviousCharacter() // ���� ��ư => ���� ĳ���� �̹��� 
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

    public void StartInGame()  // Start ��ư => �������� ���� UI Ȱ��ȭ
    {
        stage_Select.SetActive(true);

        // �÷��̾ ������ ĳ���� �ε����� Save�ý����� �̿���, �ΰ��� ������ ������ �ѱ�
        Save_System.instance.Save_Character(currentIndex);
    }

    public void GoInGame()
    {
        stage_Select.SetActive(false);
        loading_IMG.SetActive(true);
        Save_System.instance.LoadSceneManager("Stage");
    }

    // ���� ������ �÷��̾�� ĳ�������� Ȯ��
    // �ƴ� ��� ��ư ��ȣ�ۿ� ����
    public void CheckISPlayable()
    {      
        int nowLevel = Save_System.instance.level;

        // �÷��̾ ������ ĳ���� �ε����� ������ �������� ���ٸ� ��Ȱ��ȭ
        gamePlay_Btn.interactable = currentIndex > nowLevel ? false : true;
  
    }
}
