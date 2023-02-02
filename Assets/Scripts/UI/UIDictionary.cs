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
        plantName[0] = "�˷ο�";
        plantName[1] = "������";
        plantName[2] = "�ǽ���";
        plantName[3] = "�ʸ�������";
        plantName[4] = "���";
        plantName[5] = "����丶��";
        plantInfo[0] = "�˷ο��� ũ������̾ư� �˷ο����� �����ػ��� �����Ĺ��� ��ȸ, ������ȸ��� �ϴµ�, ��ȸ�� �˷ο��� '�ο�'�� ������ ���̴�. �ߵ�, ���ٰ���ī��, ������ī ���ΰ� �������� �� 200�� ������ �ִ�. ����Ʈ���׸������θ������� ��������� ���ǰ� �־��ٰ� �Ѵ�. ���� �Ǵ� �����̷� �����ϸ� �������� ����ȴ�. ���ϾƸ޸�ī, ���������� �˷ο�����ε� �˷��� �ٺ��̵����˷ο��� ����ϴµ� �� �������� ���� �� �� �ִ� ���� �Ĺ��̱⵵ �ϴ�.";
        plantInfo[1] = "�����ʴ� �������� �������̸� ���ٰ���ī���� �����Ѵ�. �� ���� ��������ī�� �ض���ȭ��, ���Ƹ޸�ī�� ������ä���ʼӰ� �ٿ����̴�. ��� ������ �з�ü�迡���� �� �ӵ��� �ٳ����� �����ִ� ���ʰ��� �з���Ű�⵵ �Ѵ�. �����ʼ��� ���� ���������� ����������, �׵��� �� ������ ���°� �ĺ��Ǿ���.";
        plantInfo[2] = "�ǽ����� �������� �����̴�. ������ ������׷� �ڶ�� ���� ������ '�ǽ���', �� ��������� ������ �پ���. ����� ��Ư�� �� �ƴ϶�, Ŀ�ٶ��� ȭ���� ���� �켭 ��������� ���δ�. ���� �ʺ����� ���� ������ �Ǵµ�, ���� ���ĺ��� ����� �� �Ϸ縸 ��ٰ� ���� ���� ���� Ư¡�� �ִ�.";
        plantInfo[3] = "�ʸ�������� �߱������� �����ϴ� ��ͽĹ����̴�. ���Ӽ� �����ο� ������ ���� �ع� 1,500~3,000m(4,900~9,800ft)�� ���� �ִ� �״����� ������ �������� �ڶ���. ���� ������������ ���� ���⿡ ó�� ������ ������������ ���� �θ� ���� ����Ĺ� �� �ϳ��̴�.";
        plantInfo[4] = "����� ȫ�繫��� �ϸ� ���̴� Ǯ�� ���̴� 1m �����̴�. ���ó� ���� ����ϴ� ��ٰ� ����� ������ ���������� �����Ǿ� 13������� ������ �θ� ���޵Ǿ���. �ѱ��� ���� �ñ�� 16���� �����̴�.";
        plantInfo[5] = "����丶��� 2~3cm ���� ũ���� �丶���, ���� ĥ�� �Ϻΰ� ����� ������ ���ֵȴ�.������ �ڶ�� ���ػ��̴�. ��� 1800��� �ʺ��� �����Ͽ���. �����ӿ� ���ϴ� �Ŀ� �۹��μ�, ���̳� ���� ���� ��� �κп��� �丶��� ����ϳ� ���Ű� ���� 2~3cm�̸� ������ ���.���׸��� ���� ���� �Ͽ� ����丶���� �Ҹ���. �丶��� ���� ����ä���̴�.�丶�亸�� �絵�� �� �� ������, �Ա⿡ �� �����Ͽ� �����̳� �ĽĿ����� ������� ��� �Դ´�.";
        plantClass[0] = "��¥���";
        plantClass[1] = "������";
        plantClass[2] = "ī�����ʶ󷹽���";
        plantClass[3] = "��̸�";
        plantClass[4] = "�̳�����";
        plantClass[5] = "������";
        plantKind[0] = "ũ������̾ư�";
        plantKind[1] = "�ض���ȭ��";
        plantKind[2] = "�������";
        plantKind[3] = "����Ǯ��";
        plantKind[4] = "�̳�����";
        plantKind[5] = "������";
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
        AudioManager.GetInstance().PlaySfx("��");
        gameObject.SetActive(false);
    }

    private void OnClickCloseDetail()
    {
        AudioManager.GetInstance().PlaySfx("��");
        plantDetail.gameObject.SetActive(false);
    }

    private void OnClickDetail()
    {
        AudioManager.GetInstance().PlaySfx("��");
        for (int i = 0; i<btnPlantList.Length; i++)
        {
            int idx = i;
            btnPlantList[idx].onClick.AddListener(() => { OnClickDetailOpen(idx); });
        }
    }

    private void OnClickDetailOpen(int idx)
    {
        AudioManager.GetInstance().PlaySfx("��");
        string plantname = plantName[idx];
        plantDetail.gameObject.SetActive(true);
        imgPlant.sprite = Resources.Load<Sprite>($"Icon/Plant/2DPlant/{plantname}");
        txtPlantName.text = plantname;
        txtPlantKind.text = plantKind[idx];
        txtPlantClass.text = plantClass[idx];
        txtPlantInfo.text = plantInfo[idx];
    }
}
