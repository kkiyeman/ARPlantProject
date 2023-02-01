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
        AudioManager.GetInstance().PlayBgm("Tutorial");
        NextBtntxt.text = "다음";
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(false);
        Dirtxt.text = "PLANTAREA에 온 걸 환영해! 내 이름은 맑음이. 너 이곳이 처음이구나? 내가 도와줄게.";
        NextBtn.onClick.AddListener(Introduce);
        SkipBtn.onClick.AddListener(ToMainBtn);
        NextBtn.gameObject.AddComponent<AudioSource>();
        SkipBtn.gameObject.AddComponent<AudioSource>();
        
    }
    void Introduce()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        currentTuto = "Introduce";
        Dirtxt.text = "PLANTAREA는 증강현실을 이용해 공간의 제약 없이 나만의 식물을 기를 수 있는 곳이야. 이제 기능에 대해 알아볼까?";
        NextBtnChange();
    }

    void BottomTutoBtn()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        Dirtxt.text = "화면 아래는 식물 성장 관련 버튼들이야. 각각의 버튼을 눌러봐!";
        BottomStep();
    }
    void RightTutoBtn()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(true);
        Dirtxt.text = "화면 오른쪽은 아이템 관련 버튼들이야. 각각 버튼을 눌러봐!";
        NextBtn.gameObject.SetActive(false);
        RightStep();
    }
    void TopTutoBtn()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(true);
        Dirtxt.text = "화면 위쪽은 플레이어 관련 창들이야. 눌러서 정보를 확인해!";
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
                AudioManager.GetInstance().PlaySfx("띠딩");
            

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
            AudioManager.GetInstance().PlaySfx("띠딩");

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
            AudioManager.GetInstance().PlaySfx("띠딩");

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
        
        NextBtnChange();
        string[,] txtList = new string[,]
        { { "물뿌리개를 이용해 식물에 물을 줄 수 있어요. 수분도가 너무 높거나 낮으면 식물이 죽으니 주의하세요!", "물", "CryStr"},
        {"영양제를 이용해 식물에 영양을 줄 수 있어요. 영양도가 너무 높거나 낮으면 식물이 질병에 걸립니다.","영양제", "SadStr"},
        { "칭찬은 하루에 1회 가능합니다. 칭찬받은 식물은 영양도와 수분도를 조금 올려줍니다.","Growth2","SmileTalkStr"},
        {"상태창입니다. 식물의 상태를 확인할 수 있고 식물의 이름,메모도 남길 수 있는 창이니 자주 확인해보세요!" ,"책","SmileStr"}};

        string v = txtList[index, 0].ToString();
        Dirtxt.text = v;
        AudioManager.GetInstance().PlaySfx($"{txtList[index,1]}");
        Character.sprite = Resources.Load<Sprite>($"Character/{txtList[index, 2]}");

    }
    void RightSetBtn(int index)
    {
        currentTuto = "Right";
        NextBtntxt.text = "위쪽";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        
        NextBtnChange();
        string[,] txtList = new string[,]
        { { "화분에 씨앗을 심을 수 있습니다. 씨앗은 농작물과 관상용으로 나뉩니다. 원하는 씨앗을 심어보세요!","흙","SmileTalk" },
        { "상점에서 씨앗, 도구 등 아이템을 구매해보세요! 식물을 키우는 데 도움이 됩니다.","Buy2","TalkStr" },
        { "키우는 식물의 정보를 도감에서 확인해보세요! 모든 식물을 획득해 도감을 모두 모아보세요!","책덮기","SmileTalkStr"},
        {"인벤토리 창에서 가지고 있는 아이템을 확인할 수 있습니다.","뿅","Smile2"}};

        string v = txtList[index,0].ToString();
        Dirtxt.text = v;
        AudioManager.GetInstance().PlaySfx($"{txtList[index, 1]}");
        Character.sprite = Resources.Load<Sprite>($"Character/{txtList[index,2]}");
    }
    void TopSetBtn(int index)
    {
        currentTuto = "Top";
        NextBtntxt.text = "메인으로";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        NextBtnChange();
        string[,] txtList = new string[,]
        { { "현재 날씨와 시간을 알 수 있습니다." ,"뿅", "SmileTalk" },
        {"현재 플레이어의 기력입니다. 행동마다 기력을 소모하고 기력이 부족하면 행동을 할 수 없습니다.","Growth1" ,"SmileStr"},
        { "상점에서 사용 가능한 골드입니다. 시스템 보상을 받거나 아이템을 팔아 획득 가능합니다.", "Buy2","TalkStr"} };

        string v = txtList[index,0].ToString();
        Dirtxt.text = v;
        AudioManager.GetInstance().PlaySfx($"{txtList[index, 1]}");
        Character.sprite = Resources.Load<Sprite>($"Character/{txtList[index, 2]}");
    }
    void ToMainBtn()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        Dirtxt.text = "자! 이제 기본적인건 알려줬으니 내 친구들도 잘 기를 수 있지? " +
            "도움이 필요하면 언제든지 옵션의 도움말을 참고해!";
        Invoke("ToMain", 5);

    }
    void ToMain()
    {

        SceneManager.LoadScene("Plant");
    }

    void NextBtnChange()
    {
        if (currentTuto == "Introduce")
            NextBtn.onClick.AddListener(BottomTutoBtn);
        if (currentTuto == "Bottom")
            NextBtn.onClick.AddListener(RightTutoBtn);
            
            
        else if(currentTuto == "Right")
            NextBtn.onClick.AddListener(TopTutoBtn);
        else if(currentTuto == "Top")
            NextBtn.onClick.AddListener(ToMainBtn);
    }
}   

