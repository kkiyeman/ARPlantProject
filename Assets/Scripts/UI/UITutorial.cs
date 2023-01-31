using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    [Header("띄울 영역")]
    [SerializeField] GameObject bottomSide;
    [SerializeField] GameObject topSide;
    [SerializeField] GameObject rightSide;
    [SerializeField] GameObject status;

    [Header("포문")]
    [SerializeField] Image[] BottomArrows;
    [SerializeField] Image[] TopArrows;
    [SerializeField] Image[] RightArrows;
    [SerializeField] Button[] BottomBtnList;
    [SerializeField] Button[] RightBtnList;
    [SerializeField] Button[] TopBtnList;

    [Header("중앙")]
    [SerializeField] Button NextBtn;
    [SerializeField] Button SkipBtn;
    [SerializeField] Text Dirtxt;
    [SerializeField] Text NextBtntxt;
    [SerializeField] Image Character;

    int index;
    string currentTuto;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

        NextBtntxt.text = "다음";
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(false);
        Dirtxt.text = "다음 버튼을 눌러 튜토리얼을 시작하세요!";
        NextBtn.onClick.AddListener(BottomTutoBtn);
        SkipBtn.onClick.AddListener(ToMainBtn);

    }

    void BottomTutoBtn()
    {
        Dirtxt.text = "화면 아래는 식물 성장 관련 버튼들입니다. 버튼을 눌러보세요!";
        BottomStep();
    }
    void RightTutoBtn()
    {
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(true);
        Dirtxt.text = "화면 오른쪽은 유저 인터페이스 관련 버튼들입니다. 버튼을 눌러보세요!";
        NextBtn.gameObject.SetActive(false);
        RightStep();
    }
    void TopTutoBtn()
    {
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(true);
        Dirtxt.text = "화면 위쪽은 플레이어 관련 UI들입니다. 눌러서 정보를 확인하세요.";
        NextBtn.gameObject.SetActive(false);
        TopStep();
    }

    void BottomStep()
    {       
        bottomSide.gameObject.SetActive(true);
        
        for (int i = 0; i < BottomBtnList.Length; i++)
            {
                int index = i;
                BottomBtnList[index].gameObject.AddComponent<AudioSource>();
            

            BottomBtnList[index].onClick.AddListener(() => { BottomSelectedArrow(index); });
            BottomBtnList[index].onClick.AddListener(() => { BottomSetBtn(index); });
                Debug.Log("버튼 셋팅 완료");
            NextBtn.gameObject.SetActive(false);
            }
    }
    void RightStep()
    {       
        for (int i = 0; i < RightBtnList.Length; i++)
        {
            int index = i;
            RightBtnList[index].gameObject.AddComponent<AudioSource>();
            

            RightBtnList[index].onClick.AddListener(() => { RightSelectedArrow(index); });
            RightBtnList[index].onClick.AddListener(() => { RightSetBtn(index); });
            Debug.Log("버튼 셋팅 완료");
            NextBtn.gameObject.SetActive(false);

            BottomBtnList[index].onClick.RemoveAllListeners();

        }

    }
    void TopStep()
    {
        for (int i = 0; i < TopBtnList.Length; i++)
        {
            int index = i;
            TopBtnList[index].gameObject.AddComponent<AudioSource>();
           

            TopBtnList[index].onClick.AddListener(() => { TopSetBtn(index); });
            TopBtnList[index].onClick.AddListener(() => { TopSelectedArrow(index); });
            Debug.Log("버튼 셋팅 완료");
            NextBtn.gameObject.SetActive(false);

            RightBtnList[index].onClick.RemoveAllListeners();
        }

    }

    void BottomSelectedArrow(int num)
    {
        BottomArrows[index].gameObject.SetActive(false);
        BottomArrows[num].gameObject.SetActive(true);
        index = num;
    }
  
    void RightSelectedArrow(int num)
    {
        RightArrows[index].gameObject.SetActive(false);
        RightArrows[num].gameObject.SetActive(true);
        index = num;
    }
    void TopSelectedArrow(int num)
    {
        TopArrows[index].gameObject.SetActive(false);
        TopArrows[num].gameObject.SetActive(true);
        index = num;
    }

    void BottomSetBtn(int index)
    {
        audioManager = GetComponent<AudioManager>();
        currentTuto = "Bottom";
        NextBtntxt.text = "오른쪽";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        audioManager.PlaySfx("띠딩");
        NextBtnChange();
        string[] txtList = new string[]
        { "물뿌리개를 이용해 식물에 물을 줄 수 있어요. 수분도가 너무 높거나 낮으면 식물이 죽으니 주의하세요!" ,
        "영양제를 이용해 식물에 영양을 줄 수 있어요. 영양도가 너무 높거나 낮으면 식물이 질병에 걸립니다.",
        "칭찬은 하루에 1회 가능합니다. 칭찬받은 식물은 영양도와 수분도를 조금 올려줍니다.",
        "화분에 씨앗을 심을 수 있습니다. 씨앗은 농작물과 관상용으로 나뉩니다. 원하는 씨앗을 심어보세요!" };

        string v = txtList[index].ToString();
        Dirtxt.text = v;

    }
    void RightSetBtn(int index)
    {
        currentTuto = "Right";
        NextBtntxt.text = "위쪽";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        
        NextBtnChange();
        string[] txtList = new string[]
        { "화분에 씨앗을 심을 수 있습니다. 씨앗은 농작물과 관상용으로 나뉩니다. 원하는 씨앗을 심어보세요!",
        "상점에서 씨앗, 도구 등 아이템을 구매해보세요! 식물을 키우는 데 도움이 됩니다.",
        "키우는 식물의 정보를 도감에서 확인해보세요! 모든 식물을 획득해 도감을 모두 모아보세요!",
        "인벤토리 창에서 가지고 있는 아이템을 확인할 수 있습니다."};

        string v = txtList[index].ToString();
        Dirtxt.text = v;

    }
    void TopSetBtn(int index)
    {
        currentTuto = "Top";
        NextBtntxt.text = "메인으로";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        NextBtnChange();
        string[] txtList = new string[]
        { "현재 날씨와 시간을 알 수 있습니다." ,
        "현재 플레이어의 기력입니다. 행동마다 기력을 소모하고 기력이 부족하면 행동을 할 수 없습니다.",
        "상점에서 사용 가능한 골드입니다. 시스템 보상을 받거나 아이템을 팔아 획득 가능합니다.", ""};

        string v = txtList[index].ToString();
        Dirtxt.text = v;
    }
    void ToMainBtn()
    {
        SceneManager.LoadScene("Plant");
    }
    void NextBtnChange()
    {
        if (currentTuto == "Bottom")
            NextBtn.onClick.AddListener(RightTutoBtn);
            
            
        else if(currentTuto == "Right")
            NextBtn.onClick.AddListener(TopTutoBtn);
        else if(currentTuto == "Top")
            NextBtn.onClick.AddListener(ToMainBtn);
    }
}   

