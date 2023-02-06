using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    public string[,] HelpList = new string[,]{
        { "�Ĺ� �ɱ�" , "�Ĺ��� ȭ�п� ������ ������ �ڶ󳳴ϴ�. ������ �������� ������ ȭ�п� �ɰ� �̸��� �������.","(1/5)"}, /*1��*/
        { "�Ĺ� �⸣��","�Ĺ����� ���� �ְ�, �������� �ְ� Ī���� ���� �� �ֽ��ϴ�. ���絵�� 0�����̰ų�, ���е��� �ʹ� ���ų� ������ �Ĺ��� �׾��.","(2/5)"}, /*2��*/
        { "�Ĺ� �����̻�","�Ĺ��� ������ �ʹ� ���ų�, ���絵�� �ʹ� ���ų� ������ �Ĺ��� �����̻��� ����ϴ�. �Ĺ��� ����� ���ߴٸ� ����â�� Ȯ���غ�����!","(3/5)"}, /*3��*/
        { "�Ĺ� Ī���ϱ�","�Ĺ��� Ī���� ������ �� �ڶ󳭴�ϴ�. �Ϸ翡 1�� Ī���� ���� ���е��� ���絵�� ȹ���ϼ���!","(4/5)"}, /*4��*/
        { "�Ĺ� ��ġ�ϱ�","������ �Ĺ��� ���ϴ� ��ġ�� �Űܺ�����! �� ���� ������ �������� �ٲ�� �ð�! Ȩ��������� �Բ� �����غ���~","(5/5)"} /*5��*/
    };


    // ����ȭ���ư
    public Button CloseBtn; // �ݴ� ��ư
    public Button HelpBtn;  // ���� ��ư
    public Button SoundBtn; // ���弳�� ��ư
    public Button ExitBtn;  // �������� ��ư

    // ����ȭ��
    public Button SoundBackBtn; // ���忡�� �������� ����
    public Slider Bgm;          // BGM �����̴�
    public Slider SFX;          // SFX �����̴�

    // ����ȭ��
    public Button HelpBackBtn; // ���򸻿��� �������� ����
    public Button NextBtn;     //
    public Button PrevBtn;
    public Image ExampleImg;
    public Text HelpTitle;
    public Text HelpTxt;
    public Text HelpCount;

    // �гε�
    public GameObject OptionPanel;
    public GameObject HelpPanel;
    public GameObject SoundPanel;
    public GameObject MainPanel;

    // ��Ÿ
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
        AudioManager.GetInstance().PlaySfx("��");
        OptionPanel.gameObject.SetActive(false);
    }

    void OpenHelp()
    {
        AudioManager.GetInstance().PlaySfx("��");
        HelpPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
    }
    void HelptoMain()
    {
        AudioManager.GetInstance().PlaySfx("��");
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
        AudioManager.GetInstance().PlaySfx("��");
        SoundPanel.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
    }

    void SoundtoMain()
    {
        AudioManager.GetInstance().PlaySfx("��");
        MainPanel.gameObject.SetActive(true);
        SoundPanel.gameObject.SetActive(false);
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
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
        Debug.Log($"{index}��° �̹����� �ҷ��ɴϴ�.");
        AudioManager.GetInstance().PlaySfx("��");
        
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