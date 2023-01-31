using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    public Button bottomOnbtn;
    public Button topOnbtn;
    public Button rightOnbtn;
    public Button WatertutoBtn;
    public Button NutritutoBtn;
    public Button CommenttutoBtn;
    public Button SeedtutoBtn;

    public GameObject bottomSide;
    public Image topSide;
    public Image rightSide;
    public Image status;
    public Image AlphaBg;
    public Image[] AlphaBgList;
    public Image BgImg;

    public Button[] BottomBtnList;
    public Button WaterBtn;
    public Button NextBtn;

    public Text Dirtxt;

    public AudioSource[] NarList;
    public AudioSource Nar1;

    public AudioClip[] NarclipList;
    public AudioClip NarClip1;
    public AudioClip NarClip2;

    public int TutorialStep;

    // Start is called before the first frame update
    void Start()
    {
        bottomOnbtn.onClick.AddListener(BottomTutoBtn);
        rightOnbtn.onClick.AddListener(RightTutoBtn);
        topOnbtn.onClick.AddListener(TopTutoBtn);
        WaterBtn.onClick.AddListener(WaterBtnOn);

        StartCoroutine(TutorialStart());
        TutorialStep = 0;
    }
    IEnumerator TutorialStart()
    {
        Step1();
        yield return new WaitWhile(() => TutorialStep < 1);
        Step2();
        yield return new WaitWhile(() => TutorialStep < 2);
        Step3();
        yield return new WaitWhile(() => TutorialStep < 3);


    }
    void Step1()
    {

        Dirtxt.text = "ȭ�� �Ʒ� �κ��� �Ĺ� ���� ���� ��ư���Դϴ�.";
        NextBtn.gameObject.SetActive(true);
        bottomSide.gameObject.SetActive(true);

/*        for (int i = 0; i < BottomBtnList.Length; i++)
        {
            int index = i;
            // BottomBtnList[index].gameObject.AddComponent<AudioSource>();
            BottomBtnList[index].onClick.AddListener(() => this.Btuto(index));
            Debug.Log("��ư ���� �Ϸ�");
        }*/
    }
    void Step2()
    { 
    
    }
    void Step3()
    {

    }

    void BottomTutoBtn()
    {
        
    }
    void RightTutoBtn()
    {
        rightSide.gameObject.SetActive(true);  
        topSide.gameObject.SetActive(false);
        bottomSide.gameObject.SetActive(false);
    }
    void TopTutoBtn()
    {
        topSide.gameObject.SetActive(true);
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
    }
    IEnumerator BottomTuto(int index)
    {
        Nar1.clip = Resources.Load<AudioClip>($"NarClip{index}");
        Nar1.Play();
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!Nar1.isPlaying)
            {
                WatertutoBtn.gameObject.SetActive(true);
                bottomSide.gameObject.SetActive(false);
                WaterBtn.gameObject.SetActive(true);
                Dirtxt.text = "��ư�� ����������!";
                BottomBtnList[index].gameObject.SetActive(false);


                /*Nar1.clip = NarClip2;
                Nar1.Play();
                Nar1.loop = true; */

            }

        }
    }
    void WaterBtnOn()
    { 
        WaterBtn.gameObject.SetActive(false);

    }
    void Btuto(int index)
    {
        StartCoroutine("BottomTuto");
        
        string[,] AnswertxtList = new string[,]{
        { "��ȣ�ڿ� ��ӵ��� ���� ���� ���� �ȵſ�." , "-��� ���� �������� �θ���̳� ��ȣ�ڿ���, ���� ��ġ�� ������ �����ؾ��ؿ�." , ""}, /*1��*/
        { "��ȣ���� �ʷϺ��� �����϶� �����ؼ� �ǳʸ� �ȵſ�.","-�����ϰ� ���� ��ȣ�� ��ٷȴ�, �� ������ �¿츦 Ȯ���ϰ� ���� ��� Ⱦ�ܺ����� �ǳʰ����ؿ�.",""}, /*2��*/
        { "�𸣴� ����� �Ժη� �����ָ� �ȵſ�","-�𸣴� ����� �ִ� ������ �԰ų� �𸣴� ����� ���� Ÿ�� �ȵſ�.","-����� ��̵鿡�� ���ʹ޶�� ���� �ʾƿ�.������ ������ û�Ҷ� �� �ֺ��� ����� ���ʹ޶�� �����ϼ���."}, /*3��*/
        { "������ �ֺ��� �ٰ����� �ȵſ�.","-������ ������ ������ �������ų� ������ �ü��� ������ ���� �־��.","-�������� �������̴��� �����ϰ� �ٸ� ��� ���ư���."}, /*4��*/
        { "�ƹ��� �� �ƴ� ��̾ ȥ�ڼ� ���󰡸� �ȵſ�.","-�� �ƴ� ��̾ ȥ�� ���󰡸� �����ؿ�.","-Ȥ�� ���� �ʹٸ� �θ���̳� ��ȣ�ڿ��� ��� ������ �˸��� ����� �ް� �����ؿ�."} /*5��*/
    };
    }
}   
