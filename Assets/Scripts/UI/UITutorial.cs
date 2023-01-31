using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    [Header("��� ����")]
    [SerializeField] GameObject bottomSide;
    [SerializeField] GameObject topSide;
    [SerializeField] GameObject rightSide;
    [SerializeField] GameObject status;

    [Header("����")]
    [SerializeField] Image[] BottomArrows;
    [SerializeField] Image[] TopArrows;
    [SerializeField] Image[] RightArrows;
    [SerializeField] Button[] BottomBtnList;
    [SerializeField] Button[] RightBtnList;
    [SerializeField] Button[] TopBtnList;

    [Header("�߾�")]
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

        NextBtntxt.text = "����";
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(false);
        Dirtxt.text = "���� ��ư�� ���� Ʃ�丮���� �����ϼ���!";
        NextBtn.onClick.AddListener(BottomTutoBtn);
        SkipBtn.onClick.AddListener(ToMainBtn);

    }

    void BottomTutoBtn()
    {
        Dirtxt.text = "ȭ�� �Ʒ��� �Ĺ� ���� ���� ��ư���Դϴ�. ��ư�� ����������!";
        BottomStep();
    }
    void RightTutoBtn()
    {
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(true);
        Dirtxt.text = "ȭ�� �������� ���� �������̽� ���� ��ư���Դϴ�. ��ư�� ����������!";
        NextBtn.gameObject.SetActive(false);
        RightStep();
    }
    void TopTutoBtn()
    {
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(true);
        Dirtxt.text = "ȭ�� ������ �÷��̾� ���� UI���Դϴ�. ������ ������ Ȯ���ϼ���.";
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
                Debug.Log("��ư ���� �Ϸ�");
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
            Debug.Log("��ư ���� �Ϸ�");
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
            Debug.Log("��ư ���� �Ϸ�");
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
        NextBtntxt.text = "������";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        audioManager.PlaySfx("���");
        NextBtnChange();
        string[] txtList = new string[]
        { "���Ѹ����� �̿��� �Ĺ��� ���� �� �� �־��. ���е��� �ʹ� ���ų� ������ �Ĺ��� ������ �����ϼ���!" ,
        "�������� �̿��� �Ĺ��� ������ �� �� �־��. ���絵�� �ʹ� ���ų� ������ �Ĺ��� ������ �ɸ��ϴ�.",
        "Ī���� �Ϸ翡 1ȸ �����մϴ�. Ī������ �Ĺ��� ���絵�� ���е��� ���� �÷��ݴϴ�.",
        "ȭ�п� ������ ���� �� �ֽ��ϴ�. ������ ���۹��� ��������� �����ϴ�. ���ϴ� ������ �ɾ����!" };

        string v = txtList[index].ToString();
        Dirtxt.text = v;

    }
    void RightSetBtn(int index)
    {
        currentTuto = "Right";
        NextBtntxt.text = "����";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        
        NextBtnChange();
        string[] txtList = new string[]
        { "ȭ�п� ������ ���� �� �ֽ��ϴ�. ������ ���۹��� ��������� �����ϴ�. ���ϴ� ������ �ɾ����!",
        "�������� ����, ���� �� �������� �����غ�����! �Ĺ��� Ű��� �� ������ �˴ϴ�.",
        "Ű��� �Ĺ��� ������ �������� Ȯ���غ�����! ��� �Ĺ��� ȹ���� ������ ��� ��ƺ�����!",
        "�κ��丮 â���� ������ �ִ� �������� Ȯ���� �� �ֽ��ϴ�."};

        string v = txtList[index].ToString();
        Dirtxt.text = v;

    }
    void TopSetBtn(int index)
    {
        currentTuto = "Top";
        NextBtntxt.text = "��������";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        NextBtnChange();
        string[] txtList = new string[]
        { "���� ������ �ð��� �� �� �ֽ��ϴ�." ,
        "���� �÷��̾��� ����Դϴ�. �ൿ���� ����� �Ҹ��ϰ� ����� �����ϸ� �ൿ�� �� �� �����ϴ�.",
        "�������� ��� ������ ����Դϴ�. �ý��� ������ �ްų� �������� �Ⱦ� ȹ�� �����մϴ�.", ""};

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

