using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Music_System.cs
// 1. �� ���� �´� ������� ����
// 2. ���� ����ɶ����� �׿� �´� ��������� �ڿ������� ��ȯ
// 3. ������ ������ ���� ���� �������� ����


public class Music_System : MonoBehaviour
{
   public static Music_System instance; // �̱��� ����

    public AudioSource backgroundMusic;
    public AudioClip title_BGM;     // Ÿ��Ʋ �޴� ����
    public AudioClip choice_BGM;    // ĳ���� ���� �޴� ����
    public AudioClip battle_BGM;    // ���� ����
    public AudioClip boss_BGM;      // ���� ����

    public Dictionary<string, AudioClip> bgms;
    public float time = 1f; // ���� ��ȯ �ð�

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        // ���� �ε� �ɶ� �ڵ����� ȣ��
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void Start()
    {
        bgms = new Dictionary<string, AudioClip>()
        {
            {"Main_Title", title_BGM},
            {"ChoiceCharacter", choice_BGM }
        };
    }

    // ���� �ε� �� �� �ڵ����� ȣ���
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        PlayBGM();
    }

    // ���� �� �̸��� ������, Dictionary�� ����� ���� ����
    // ������ �ٲٴ� �ڷ�ƾ ����
    public void PlayBGM()
    {
        string nowSceneName = SceneManager.GetActiveScene().name; 

        if(bgms.ContainsKey(nowSceneName))
        {
            StartCoroutine(ChangeBGM(bgms[nowSceneName]));
        }
        else
        {
            Debug.LogWarning("���� ���� �´� ��������� �����ϴ�.");
        }
    }

    IEnumerator ChangeBGM(AudioClip newclip)
    {
        //--- ���� ���߱� --- // 

        float volume = backgroundMusic.volume;
        float ntime = 0;

        while(ntime < time)
        {
            ntime+= Time.deltaTime;
            backgroundMusic.volume = Mathf.Lerp(volume, 0, ntime / time);
            yield return null;
        }

        // --- �뷡 �ٲٱ� --- //

        backgroundMusic.clip = newclip;
        backgroundMusic.volume = 0;
        backgroundMusic.Play();

        // --- ���� �ø��� --- // 

        ntime = 0;
        while (ntime < time)
        {
            ntime+= Time.deltaTime;
            backgroundMusic.volume = Mathf.Lerp(0, volume, ntime / time);
            yield return null;
        }
    }
}
