using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    // 메인화면버튼
    public Button CloseBtn;
    public Button HelpBtn;
    public Button SoundBtn;
    public Button ExitBtn;
    
    // 사운드화면
    public Button SoundBackBtn;
    public Slider Bgm;
    public Slider SFX;

    // 도움말화면
    public Button HelpBackBtn;
    public Button[] buttons;
    public Image[] ExampleImg;
    public string[,] HelpList;


    // 패널들
    public GameObject Option;
    public GameObject Help;
    public GameObject Sound;
    public GameObject Main;

    // 기타
    AudioManager audioManager;
    public AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        

        CloseBtn.onClick.AddListener(CloseOption);
        HelpBtn.onClick.AddListener(OpenHelp);
        SoundBtn.onClick.AddListener(OpenSound);
        ExitBtn.onClick.AddListener(Exit);

        HelpBackBtn.onClick.AddListener(HelptoMain);
        SoundBackBtn.onClick.AddListener(SoundtoMain);

        Bgm.value = 0.5f;
        SFX.value = 0.5f;

        if (buttons != null)
        {
            for (int i = 0; 1 < buttons.Length; i++)
            {
                int index = i;
                buttons[index].gameObject.AddComponent<AudioSource>();

                buttons[index].onClick.AddListener(() => this.ShowHelp(index));

            }
        }

    }

    void CloseOption()
    { 
            Option.gameObject.SetActive(false);
    }

    void OpenHelp()
    { 
        Help.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }
    void HelptoMain()
    {
        Help.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
    }

    void OpenSound()
    {
        Sound.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }

    void SoundtoMain()
    { 
        Main.gameObject.SetActive(true);
        Sound.gameObject.SetActive(false);
    }

    void Exit()
    { 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void SetSFXVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("SFX", Mathf.Log10(SFX.value) * 20);
    }
    public void SetBgmVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("BGM", Mathf.Log10(Bgm.value) * 20);
    }

    public void ShowHelp(int index)
    {
        string[,] AnswertxtList = new string[,]{
        { "식물 심기" , "식물은 화분에 씨앗을 심으면 자라납니다. 씨앗을 상점에서 구매해 화분에 심어" , ""}, /*1행*/
        { "식물 기르기","-안전하게 다음 신호를 기다렸다, 꼭 도로의 좌우를 확인하고 손을 들고 횡단보도를 건너가야해요.",""}, /*2행*/
        { "식물 수확하기","-모르는 사람이 주는 음식을 먹거나 모르는 사람의 차를 타면 안돼요.","-어른들은 어린이들에게 도와달라고 하지 않아요.누군가 도움을 청할땐 그 주변의 어른에게 도와달라고 전달하세요."}, /*3행*/
        { "식물 제거하기","-공사장 위에서 물건이 떨어지거나 공사장 시설이 무너질 수도 있어요.","-공사장이 지름길이더라도 안전하게 다른 길로 돌아가요."}, /*4행*/
        { "식물 배치하기","-잘 아는 어른이어도 혼자 따라가면 위험해요.","-혹시 가고 싶다면 부모님이나 보호자에게 어디 가는지 알린뒤 허락을 받고 가야해요."} /*5행*/
    };

    }


    
}