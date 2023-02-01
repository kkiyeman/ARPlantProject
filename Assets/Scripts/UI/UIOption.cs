using System;
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
    public Image ExampleImg;
    public Text HelpTitle;
    public Text HelpTxt;
    public Text HelpCount;
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
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[index].gameObject.AddComponent<AudioSource>();
                

                buttons[index].onClick.AddListener(() => this.ShowHelp(index));

            }
        }

    }

    void CloseOption()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        Option.gameObject.SetActive(false);
    }

    void OpenHelp()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        Help.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }
    void HelptoMain()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        Help.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
    }

    void OpenSound()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        Sound.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }

    void SoundtoMain()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
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
        string[,] HelpList = new string[,]{
        { "식물 심기" , "식물은 화분에 씨앗을 심으면 자라납니다. 씨앗을 상점에서 구매해 화분에 심고 이름을 지어보세요.","(1/5)"}, /*1행*/
        { "식물 기르기","식물에게 물을 주고, 영양제를 주고 칭찬을 해줄 수 있습니다. 영양도가 0이하이거나, 수분도가 너무 많거나 적으면 식물이 죽어요.","(2/5)"}, /*2행*/
        { "식물 상태이상","식물의 수분이 너무 많거나, 영양도가 너무 낮거나 높으면 식물의 상태이상이 생깁니다. 식물이 노랗게 변했다면 상태창을 확인해보세요!","(3/5)"}, /*3행*/
        { "식물 칭찬하기","식물도 칭찬을 받으면 잘 자라난답니다. 하루에 1번 칭찬을 통해 수분도와 영양도를 획득하세요!","(4/5)"}, /*4행*/
        { "식물 배치하기","나만의 식물을 원하는 위치로 옮겨보세요! 내 방이 나만의 정원으로 바뀌는 시간! 홈가드닝으로 함께 힐링해봐요~","(5/5)"} /*5행*/
    };
        string v = HelpList[index, 0].ToString();
        HelpTitle.text = v;
        
        //HelpTitle.gameObject.GetComponent<AudioSource>().Play();

        string y = HelpList[index, 1].ToString();
        HelpTxt.text = y;

        string z = HelpList[index, 2].ToString();
        HelpCount.text = z;
        
        ExampleImg.sprite = Resources.Load<Sprite>($"Image/Help/Help{index + 1}");
        Debug.Log($"{index}번째 이미지를 불러옵니다.");
        AudioManager.GetInstance().PlaySfx("뿅");

    }

}