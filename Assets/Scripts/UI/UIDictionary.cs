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
        plantInfo[0] = "�˷ο��� ũ������̾ư� �˷ο����� �����ػ��� �����Ĺ��� ��ȸ, ������ȸ��� �ϴµ�, ��ȸ�� �˷ο��� '�ο�'�� ������ ���̴�. �ߵ�, ���ٰ���ī��, ������ī ���ΰ� �������� �� 200�� ������ �ִ�. ����Ʈ���׸������θ������� ��������� ���ǰ� �־��ٰ� �Ѵ�. ���� �Ǵ� �����̷� �����ϸ� �������� ����ȴ�. ���ϾƸ޸�ī, ���������� �˷ο�����ε� �˷��� �ٺ��̵����˷ο��� ����ϴµ� �� �������� ���� �� �� �ִ� ���� �Ĺ��̱⵵ �ϴ�.";
        plantInfo[1] = "�����ʴ� �������� �������̸� ���ٰ���ī���� �����Ѵ�. �� ���� ��������ī�� �ض���ȭ��, ���Ƹ޸�ī�� ������ä���ʼӰ� �ٿ����̴�. ��� ������ �з�ü�迡���� �� �ӵ��� �ٳ����� �����ִ� ���ʰ��� �з���Ű�⵵ �Ѵ�. �����ʼ��� ���� ���������� ����������, �׵��� �� ������ ���°� �ĺ��Ǿ���.";
        plantInfo[2] = "";
        plantInfo[3] = "";
        plantInfo[4] = "";
        plantInfo[5] = "";
        plantClass[0] = "��¥���";
        plantClass[1] = "������";
        plantClass[2] = "ī�����ʶ󷹽���";
        plantClass[3] = "";
        plantClass[4] = "";
        plantClass[5] = "";
        plantKind[0] = "ũ������̾ư�";
        plantKind[1] = "�ض���ȭ��";
        plantKind[2] = "�������";
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
