using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Music_System.cs
// 1. 각 씬에 맞는 배경음악 지정
// 2. 씬이 변경될때마다 그에 맞는 배경음악을 자연스럽게 전환
// 3. 보스를 만났을 때는 전용 음악으로 변경


public class Music_System : MonoBehaviour
{
   public static Music_System instance; // 싱글턴 패턴

    public AudioSource backgroundMusic;
    public AudioClip title_BGM;     // 타이틀 메뉴 음악
    public AudioClip choice_BGM;    // 캐릭터 선택 메뉴 음악
    public AudioClip battle_BGM;    // 전투 음악
 

    public Dictionary<string, AudioClip> bgms;
    public float time = .05f; // 음악 전환 시간

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

        // 씬이 로드 될 때 자동으로 호출됨
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void Start()
    {
        bgms = new Dictionary<string, AudioClip>()
        {
            {"Main_Title", title_BGM},
            {"ChoiceCharacter", choice_BGM },
            {"Stroy_Typing", null},
            {"Stage",battle_BGM}
        };
    }

     // 씬이 로드 될 때 자동으로 호출됨
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        PlayBGM();
    }

    // 현재 씬 이름을 가져와, Dictionary에 저장된 값과 대조
    // 음악을 바꾸는 코루틴 실행
    public void PlayBGM()
    {
        string nowSceneName = SceneManager.GetActiveScene().name; 

        Debug.Log($"씬 로드 호출 // 현재 씬 이름 : {nowSceneName}");

        if(bgms.ContainsKey(nowSceneName))
        {
            StartCoroutine(ChangeBGM(bgms[nowSceneName]));
        }
        else
        {
            Debug.LogWarning("현재 씬에 맞는 배경음악이 없습니다.");
        }
    }

    IEnumerator ChangeBGM(AudioClip newclip)
    {
        //--- 볼륨 낮추기 --- // 

        float volume = backgroundMusic.volume;
        float ntime = 0;

        while(ntime < time)
        {
            ntime+= Time.deltaTime;
            backgroundMusic.volume = Mathf.Lerp(volume, 0, ntime / time);
            yield return null;
        }

        // --- 노래 바꾸기 --- //

        backgroundMusic.clip = newclip;
        backgroundMusic.volume = 0;
        backgroundMusic.Play();

        // --- 볼륨 올리기 --- // 

        ntime = 0;
        while (ntime < time)
        {
            ntime+= Time.deltaTime;
            backgroundMusic.volume = Mathf.Lerp(0, volume, ntime / time);
            yield return null;
        }
    }
}
