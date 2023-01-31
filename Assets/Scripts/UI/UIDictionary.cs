using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDictionary : MonoBehaviour
{
    [Header("Standard Dictionary")]
    [SerializeField] Button btnCloseDict;
    [SerializeField] InputField inputSearch;
    [SerializeField] Button btnSearch;
    [SerializeField] Button btnPrev;
    [SerializeField] Button btnNext;

    [Header("Plant List")]
    [SerializeField] Button[] btnPlantList;
    [SerializeField] Text[] txtIPlantList;

    [Header("Plant Detail")]
    [SerializeField] GameObject plantDetail;
    [SerializeField] Image imgPlant;
    [SerializeField] Text txtPlantName;
    [SerializeField] Text txtPlantKind;
    [SerializeField] Text txtPlantClass;
    [SerializeField] Text txtPlantInfo;
    [SerializeField] Button btnCloseDetail;
    private string[] plantInfo = new string[6];
    private string[] plantClass = new string[6];
    private string[] plantKind = new string[6];



    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
        SetButton();
        InitPlantInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitPlantInfo()
    {
        plantInfo[0] = "알로에는 크산토로이아과 알로에속의 여러해살이 다육식물로 노회, 나무노회라고도 하는데, 노회는 알로에의 '로에'를 음차한 것이다. 중동, 마다가스카르, 아프리카 남부가 원산지로 약 200여 종류가 있다. 이집트·그리스·로마에서는 기원전부터 재배되고 있었다고 한다. 종자 또는 꺾꽂이로 번식하며 소형종은 분재된다. 남북아메리카, 유럽에서는 알로에베라로도 알려진 바베이도스알로에를 재배하는데 이 종류들은 흔히 볼 수 있는 원예 식물이기도 하다.";
        plantInfo[1] = "여인초는 여인초의 유일종이며 마다가스카르에 서식한다. 이 속은 남아프리카의 극락조화속, 남아메리카의 좁은부채파초속과 근연속이다. 몇몇 오래된 분류체계에서는 이 속들을 바나나가 속해있는 파초과에 분류시키기도 한다. 여인초속은 보통 단일종으로 여겨지지만, 그동안 네 가지의 형태가 식별되었다.";
        plantInfo[2] = "";
        plantInfo[3] = "";
        plantInfo[4] = "";
        plantInfo[5] = "";
        plantClass[0] = "비짜루목";
        plantClass[1] = "생강목";
        plantClass[2] = "카리오필라레스목";
        plantClass[3] = "";
        plantClass[4] = "";
        plantClass[5] = "";
        plantKind[0] = "크산토로이아과";
        plantKind[1] = "극락조화과";
        plantKind[2] = "선인장과";
        plantKind[3] = "";
        plantKind[4] = "";
        plantKind[5] = "";
    }

    private void SetButton()
    {
        btnCloseDict.onClick.AddListener(OnClickCloseDict);
        btnCloseDetail.onClick.AddListener(OnClickCloseDetail);
        OnClickDetail();
    }


    private void OnClickCloseDict()
    {
        gameObject.SetActive(false);
    }

    private void OnClickCloseDetail()
    {
        plantDetail.gameObject.SetActive(false);
    }

    private void OnClickDetail()
    {
        for(int i = 0; i<btnPlantList.Length; i++)
        {
            int idx = i;
            btnPlantList[i].onClick.AddListener(OnClickDetailOpen);
        }
    }

    private void OnClickDetailOpen()
    {
        plantDetail.gameObject.SetActive(true);
    }
}
