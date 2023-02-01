using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    // ����ȭ���ư
    public Button CloseBtn;
    public Button HelpBtn;
    public Button SoundBtn;
    public Button ExitBtn;
    
    // ����ȭ��
    public Button SoundBackBtn;
    public Slider Bgm;
    public Slider SFX;

    // ����ȭ��
    public Button HelpBackBtn;
    public Button[] buttons;
    public Image ExampleImg;
    public Text HelpTitle;
    public Text HelpTxt;
    public Text HelpCount;
    public string[,] HelpList;


    // �гε�
    public GameObject Option;
    public GameObject Help;
    public GameObject Sound;
    public GameObject Main;

    // ��Ÿ
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
        AudioManager.GetInstance().PlaySfx("��");
        Option.gameObject.SetActive(false);
    }

    void OpenHelp()
    {
        AudioManager.GetInstance().PlaySfx("��");
        Help.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }
    void HelptoMain()
    {
        AudioManager.GetInstance().PlaySfx("��");
        Help.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
    }

    void OpenSound()
    {
        AudioManager.GetInstance().PlaySfx("��");
        Sound.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }

    void SoundtoMain()
    {
        AudioManager.GetInstance().PlaySfx("��");
        Main.gameObject.SetActive(true);
        Sound.gameObject.SetActive(false);
    }

    void Exit()
    { 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    public void SetSFXVolme()
    {
        // �α� ���� �� ����
        audioMixer.SetFloat("SFX", Mathf.Log10(SFX.value) * 20);
    }
    public void SetBgmVolme()
    {
        // �α� ���� �� ����
        audioMixer.SetFloat("BGM", Mathf.Log10(Bgm.value) * 20);
    }

    public void ShowHelp(int index)
    {
        string[,] HelpList = new string[,]{
        { "�Ĺ� �ɱ�" , "�Ĺ��� ȭ�п� ������ ������ �ڶ󳳴ϴ�. ������ �������� ������ ȭ�п� �ɰ� �̸��� �������.","(1/5)"}, /*1��*/
        { "�Ĺ� �⸣��","�Ĺ����� ���� �ְ�, �������� �ְ� Ī���� ���� �� �ֽ��ϴ�. ���絵�� 0�����̰ų�, ���е��� �ʹ� ���ų� ������ �Ĺ��� �׾��.","(2/5)"}, /*2��*/
        { "�Ĺ� �����̻�","�Ĺ��� ������ �ʹ� ���ų�, ���絵�� �ʹ� ���ų� ������ �Ĺ��� �����̻��� ����ϴ�. �Ĺ��� ����� ���ߴٸ� ����â�� Ȯ���غ�����!","(3/5)"}, /*3��*/
        { "�Ĺ� Ī���ϱ�","�Ĺ��� Ī���� ������ �� �ڶ󳭴�ϴ�. �Ϸ翡 1�� Ī���� ���� ���е��� ���絵�� ȹ���ϼ���!","(4/5)"}, /*4��*/
        { "�Ĺ� ��ġ�ϱ�","������ �Ĺ��� ���ϴ� ��ġ�� �Űܺ�����! �� ���� ������ �������� �ٲ�� �ð�! Ȩ��������� �Բ� �����غ���~","(5/5)"} /*5��*/
    };
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

}