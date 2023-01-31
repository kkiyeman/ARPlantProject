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

        Dirtxt.text = "화면 아래 부분은 식물 성장 관련 버튼들입니다.";
        NextBtn.gameObject.SetActive(true);
        bottomSide.gameObject.SetActive(true);

/*        for (int i = 0; i < BottomBtnList.Length; i++)
        {
            int index = i;
            // BottomBtnList[index].gameObject.AddComponent<AudioSource>();
            BottomBtnList[index].onClick.AddListener(() => this.Btuto(index));
            Debug.Log("버튼 셋팅 완료");
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
                Dirtxt.text = "버튼을 눌러보세요!";
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
        { "보호자와 약속되지 않은 곳은 가면 안돼요." , "-어딘가 가고 싶을때는 부모님이나 보호자에게, 가는 위치와 이유를 설명해야해요." , ""}, /*1행*/
        { "신호등의 초록불이 깜빡일때 무리해서 건너면 안돼요.","-안전하게 다음 신호를 기다렸다, 꼭 도로의 좌우를 확인하고 손을 들고 횡단보도를 건너가야해요.",""}, /*2행*/
        { "모르는 사람을 함부로 도와주면 안돼요","-모르는 사람이 주는 음식을 먹거나 모르는 사람의 차를 타면 안돼요.","-어른들은 어린이들에게 도와달라고 하지 않아요.누군가 도움을 청할땐 그 주변의 어른에게 도와달라고 전달하세요."}, /*3행*/
        { "공사장 주변은 다가가면 안돼요.","-공사장 위에서 물건이 떨어지거나 공사장 시설이 무너질 수도 있어요.","-공사장이 지름길이더라도 안전하게 다른 길로 돌아가요."}, /*4행*/
        { "아무리 잘 아는 어른이어도 혼자서 따라가면 안돼요.","-잘 아는 어른이어도 혼자 따라가면 위험해요.","-혹시 가고 싶다면 부모님이나 보호자에게 어디 가는지 알린뒤 허락을 받고 가야해요."} /*5행*/
    };
    }
}   
