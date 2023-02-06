using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    public string[,] HelpList = new string[,]{
        { "식물 심기" , "식물은 화분에 씨앗을 심으면 자라납니다. 씨앗을 상점에서 구매해 화분에 심고 이름을 지어보세요.","(1/5)"}, /*1행*/
        { "식물 기르기","식물에게 물을 주고, 영양제를 주고 칭찬을 해줄 수 있습니다. 영양도가 0이하이거나, 수분도가 너무 많거나 적으면 식물이 죽어요.","(2/5)"}, /*2행*/
        { "식물 상태이상","식물의 수분이 너무 많거나, 영양도가 너무 낮거나 높으면 식물의 상태이상이 생깁니다. 식물이 노랗게 변했다면 상태창을 확인해보세요!","(3/5)"}, /*3행*/
        { "식물 칭찬하기","식물도 칭찬을 받으면 잘 자라난답니다. 하루에 1번 칭찬을 통해 수분도와 영양도를 획득하세요!","(4/5)"}, /*4행*/
        { "식물 배치하기","나만의 식물을 원하는 위치로 옮겨보세요! 내 방이 나만의 정원으로 바뀌는 시간! 홈가드닝으로 함께 힐링해봐요~","(5/5)"} /*5행*/
    };


    // 메인화면버튼
    public Button CloseBtn; // 닫는 버튼
    public Button HelpBtn;  // 도움말 버튼
    public Button SoundBtn; // 사운드설정 버튼
    public Button ExitBtn;  // 게임종료 버튼

    // 사운드화면
    public Button SoundBackBtn; // 사운드에서 메인으로 가기
    public Slider Bgm;          // BGM 슬라이더
    public Slider SFX;          // SFX 슬라이더

    // 도움말화면
    public Button HelpBackBtn; // 도움말에서 메인으로 가기
    public Button NextBtn;     //
    public Button PrevBtn;
    public Image ExampleImg;
    public Text HelpTitle;
    public Text HelpTxt;
    public Text HelpCount;

    // 패널들
    public GameObject OptionPanel;
    public GameObject HelpPanel;
    public GameObject SoundPanel;
    public GameObject MainPanel;

    // 기타
    AudioManager audioManager;
    public AudioMixer audioMixer;
    
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioManager = AudioManager.GetInstance();
        Bgm.maxValue = 1f;
        Bgm.value = 0.1f;
        SFX.maxValue = 1f;
        SFX.value = 0.3f;

        CloseBtn.onClick.AddListener(CloseOption);
        HelpBtn.onClick.AddListener(OpenHelp);
        SoundBtn.onClick.AddListener(OpenSound);
        ExitBtn.onClick.AddListener(Exit);

        HelpBackBtn.onClick.AddListener(HelptoMain);
        SoundBackBtn.onClick.AddListener(SoundtoMain);

        NextBtn.onClick.AddListener(IndexPlus);
        PrevBtn.onClick.AddListener(IndexMinus);


        PrevBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        SetVolume();
    }

    void SetVolume()
    {
        audioManager.BgmPlayer.volume = Bgm.value;
        audioManager.SfxPlayer.volume = SFX.value;
    }
    void CloseOption()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        OptionPanel.gameObject.SetActive(false);
    }

    void OpenHelp()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        HelpPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
    }
    void HelptoMain()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        HelpPanel.gameObject.SetActive(false);
        MainPanel.gameObject.SetActive(true);
    }
    public void SetSFXVolme(float sound)
    {
        audioManager = AudioManager.GetInstance();
        audioManager.SfxPlayer.volume = sound;
        sound = SFX.value;
        audioMixer.SetFloat("SFX", sound);
    }
    public void SetBgmVolme(float sound)
    {
        audioManager = AudioManager.GetInstance();
        audioManager.BgmPlayer.volume = sound;
        sound = Bgm.value;
        audioMixer.SetFloat("BGM", sound);
    }

    void OpenSound()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        SoundPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
    }

    void SoundtoMain()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        MainPanel.gameObject.SetActive(true);
        SoundPanel.gameObject.SetActive(false);
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

/*    public void SetSFXVolme(float sound)
    { 
        sound = SFX.value;
        audioMixer.SetFloat("SFX", sound);
    }
    public void SetBgmVolme(float sound)
    {
        sound = Bgm.value;
        audioMixer.SetFloat("BGM", sound);
    }*/

    public void ShowHelp(int index)
    {
        
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

    private void IndexPlus()
    {
        index++;

        int strLength = HelpList.GetLength(0);
        if (index >= strLength)
            index = strLength - 1;

        if (index >= strLength - 1)
            NextBtn.gameObject.SetActive(false);

        PrevBtn.gameObject.SetActive(true); 
        
        ShowHelp(index);        
    }

    private void IndexMinus()
    {
        index--;

        if (index <= 0)
        {
            index = 0;
            PrevBtn.gameObject.SetActive(false);
        }

        NextBtn.gameObject.SetActive(true); 
        
        ShowHelp(index);
    }

}