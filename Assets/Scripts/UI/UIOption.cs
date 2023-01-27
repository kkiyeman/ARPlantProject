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
    public Image[] ExampleImg;
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
        string[,] AnswertxtList = new string[,]{
        { "�Ĺ� �ɱ�" , "�Ĺ��� ȭ�п� ������ ������ �ڶ󳳴ϴ�. ������ �������� ������ ȭ�п� �ɾ�" , ""}, /*1��*/
        { "�Ĺ� �⸣��","-�����ϰ� ���� ��ȣ�� ��ٷȴ�, �� ������ �¿츦 Ȯ���ϰ� ���� ��� Ⱦ�ܺ����� �ǳʰ����ؿ�.",""}, /*2��*/
        { "�Ĺ� ��Ȯ�ϱ�","-�𸣴� ����� �ִ� ������ �԰ų� �𸣴� ����� ���� Ÿ�� �ȵſ�.","-����� ��̵鿡�� ���ʹ޶�� ���� �ʾƿ�.������ ������ û�Ҷ� �� �ֺ��� ����� ���ʹ޶�� �����ϼ���."}, /*3��*/
        { "�Ĺ� �����ϱ�","-������ ������ ������ �������ų� ������ �ü��� ������ ���� �־��.","-�������� �������̴��� �����ϰ� �ٸ� ��� ���ư���."}, /*4��*/
        { "�Ĺ� ��ġ�ϱ�","-�� �ƴ� ��̾ ȥ�� ���󰡸� �����ؿ�.","-Ȥ�� ���� �ʹٸ� �θ���̳� ��ȣ�ڿ��� ��� ������ �˸��� ����� �ް� �����ؿ�."} /*5��*/
    };

    }


    
}