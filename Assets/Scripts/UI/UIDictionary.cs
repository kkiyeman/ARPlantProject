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
    private string[] plantName = new string[6];
    private string[] plantInfo = new string[6];
    private string[] plantClass = new string[6];
    private string[] plantKind = new string[6];



    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetInstance().PlayBgm("Dictionary");
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
        plantName[0] = "알로에";
        plantName[1] = "여인초";
        plantName[2] = "피쉬본";
        plantName[3] = "필리아페페";
        plantName[4] = "당근";
        plantName[5] = "방울토마토";
        plantInfo[0] = "알로에는 크산토로이아과 알로에속의 여러해살이 다육식물로 노회, 나무노회라고도 하는데, 노회는 알로에의 '로에'를 음차한 것이다. 중동, 마다가스카르, 아프리카 남부가 원산지로 약 200여 종류가 있다. 이집트·그리스·로마에서는 기원전부터 재배되고 있었다고 한다. 종자 또는 꺾꽂이로 번식하며 소형종은 분재된다. 남북아메리카, 유럽에서는 알로에베라로도 알려진 바베이도스알로에를 재배하는데 이 종류들은 흔히 볼 수 있는 원예 식물이기도 하다.";
        plantInfo[1] = "여인초는 여인초의 유일종이며 마다가스카르에 서식한다. 이 속은 남아프리카의 극락조화속, 남아메리카의 좁은부채파초속과 근연속이다. 몇몇 오래된 분류체계에서는 이 속들을 바나나가 속해있는 파초과에 분류시키기도 한다. 여인초속은 보통 단일종으로 여겨지지만, 그동안 네 가지의 형태가 식별되었다.";
        plantInfo[2] = "피쉬본은 선인장의 일종이다. 선명한 지그재그로 자라는 모양새 때문에 '피쉬본', 즉 생선뼈라는 별명이 붙었다. 모양이 독특할 뿐 아니라, 커다랗고 화려한 꽃이 펴서 관상용으로 쓰인다. 꽃은 늦봄에서 여름 즈음에 피는데, 늦은 오후부터 밤까지 딱 하루만 폈다가 지며 향이 강한 특징이 있다.";
        plantInfo[3] = "필리아페페는 중국에서만 서식하는 희귀식물종이다. 쓰촨성 남서부와 윈난성 서부 해발 1,500~3,000m(4,900~9,800ft)의 숲에 있는 그늘지고 축축한 바위에서 자란다. 고유 서식지에서는 멸종 위기에 처해 있으나 전세계적으로 가장 널리 퍼진 관상식물 중 하나이다.";
        plantInfo[4] = "당근은 홍당무라고도 하며 높이는 풀의 높이는 1m 내외이다. 오늘날 흔히 재배하는 당근과 비슷한 종류는 프랑스에서 개량되어 13세기까지 유럽에 널리 보급되었다. 한국에 들어온 시기는 16세기 무렵이다.";
        plantInfo[5] = "방울토마토는 2~3cm 정도 크기의 토마토로, 페루와 칠레 북부가 기원인 것으로 간주된다.땅에서 자라며 한해살이다. 적어도 1800년대 초부터 경작하였다. 가지속에 속하는 식용 작물로서, 잎이나 열매 거의 모든 부분에서 토마토와 비슷하나 열매가 보통 2~3cm이며 구형을 띤다.조그마한 방울과 같다 하여 방울토마토라고 불린다. 토마토와 같이 숙성채소이다.토마토보다 당도가 좀 더 높으며, 먹기에 더 간편하여 간식이나 후식용으로 사람들이 즐겨 먹는다.";
        plantClass[0] = "비짜루목";
        plantClass[1] = "생강목";
        plantClass[2] = "카리오필라레스목";
        plantClass[3] = "장미목";
        plantClass[4] = "미나리목";
        plantClass[5] = "가지목";
        plantKind[0] = "크산토로이아과";
        plantKind[1] = "극락조화과";
        plantKind[2] = "선인장과";
        plantKind[3] = "쐐기풀과";
        plantKind[4] = "미나리과";
        plantKind[5] = "가지과";
    }

    private void SetButton()
    {
        btnCloseDict.onClick.AddListener(OnClickCloseDict);
        btnCloseDetail.onClick.AddListener(OnClickCloseDetail);
        OnClickDetail();
    }


    private void OnClickCloseDict()
    {
        int i = Random.Range(1, 4);
        AudioManager.GetInstance().PlayBgm($"Plant{i}");
        AudioManager.GetInstance().PlaySfx("뿅");
        gameObject.SetActive(false);
    }

    private void OnClickCloseDetail()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        plantDetail.gameObject.SetActive(false);
    }

    private void OnClickDetail()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        for (int i = 0; i<btnPlantList.Length; i++)
        {
            int idx = i;
            btnPlantList[idx].onClick.AddListener(() => { OnClickDetailOpen(idx); });
        }
    }

    private void OnClickDetailOpen(int idx)
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        string plantname = plantName[idx];
        plantDetail.gameObject.SetActive(true);
        imgPlant.sprite = Resources.Load<Sprite>($"Icon/Plant/2DPlant/{plantname}");
        txtPlantName.text = plantname;
        txtPlantKind.text = plantKind[idx];
        txtPlantClass.text = plantClass[idx];
        txtPlantInfo.text = plantInfo[idx];
    }
}
