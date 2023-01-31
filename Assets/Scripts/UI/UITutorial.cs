using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    [Header("띄울 영역")]
    [SerializeField] GameObject bottomSide;
    [SerializeField] GameObject topSide;
    [SerializeField] GameObject rightSide;
    [SerializeField] GameObject status;

    [Header("포문")]
    [SerializeField] Image[] Arrows;
    [SerializeField] Button[] BottomBtnList;

    [Header("중앙")]
    [SerializeField] Button NextBtn;
    [SerializeField] Text Dirtxt;
    [SerializeField] Text NextBtntxt;
    [SerializeField] Image Character;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        NextBtntxt.text = "다음";
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(false);
        Dirtxt.text = "다음 버튼을 눌러 튜토리얼을 시작하세요!";
        NextBtn.onClick.AddListener(BottomTutoBtn);

    }

    void BottomTutoBtn()
    {
        Dirtxt.text = "화면 아래는 식물 성장 관련 버튼들입니다. 버튼을 눌러보세요!";
        Step1();
    }
    void RightTutoBtn()
    {
        Dirtxt.text = "화면 오른쪽은 유저 인터페이스 관련 버튼들입니다. 버튼을 눌러보세요!";
        NextBtn.gameObject.SetActive(false);
        Step2();
    }

    void Step1()
    {   
        bottomSide.gameObject.SetActive(true);
        
        for (int i = 0; i < BottomBtnList.Length; i++)
            {
                int index = i;
                BottomBtnList[index].gameObject.AddComponent<AudioSource>();

            BottomBtnList[index].onClick.AddListener(() => { SelectedArrow(index); });
            BottomBtnList[index].onClick.AddListener(() => { SetBtn(index); });
                Debug.Log("버튼 셋팅 완료");
            NextBtn.gameObject.SetActive(false);
            }
    }
    void Step2()
    { 
        
    }

    void SelectedArrow(int num)
    {
        Arrows[index].gameObject.SetActive(false);
        Arrows[num].gameObject.SetActive(true);
        index = num;

    }
    void RightTutoBtnOn()
    {
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(true);

    }
    void SetBtn(int index)
    {
        NextBtntxt.text = "건너뛰기";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        NextBtn.onClick.AddListener(RightTutoBtnOn);
        string[] txtList = new string[]
        { "물뿌리개를 이용해 식물에 물을 줄 수 있어요. 수분도가 너무 높거나 낮으면 식물이 죽으니 주의하세요!" ,
        "영양제를 이용해 식물에 영양을 줄 수 있어요. 영양도가 너무 높거나 낮으면 식물이 질병에 걸립니다.",
        "칭찬은 하루에 1회 가능합니다. 칭찬받은 식물은 영양도와 수분도를 조금 올려줍니다.",
        "화분에 씨앗을 심을 수 있습니다. 씨앗은 농작물과 관상용으로 나뉩니다. 원하는 씨앗을 심어보세요!" };

        string v = txtList[index].ToString();
        Dirtxt.text = v;

        string w = txtList[index].ToString();
        Dirtxt.text = w;

        string y = txtList[index].ToString();
        Dirtxt.text = y;

        string z = txtList[index].ToString();
        Dirtxt.text = z;
    }
}   
