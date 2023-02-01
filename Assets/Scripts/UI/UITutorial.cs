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
        AudioManager.GetInstance().PlayBgm("Tutorial");
        NextBtntxt.text = "����";
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(false);
        Dirtxt.text = "PLANTAREA�� �� �� ȯ����! �� �̸��� ������. �� �̰��� ó���̱���? ���� �����ٰ�.";
        NextBtn.onClick.AddListener(Introduce);
        SkipBtn.onClick.AddListener(ToMainBtn);
        NextBtn.gameObject.AddComponent<AudioSource>();
        SkipBtn.gameObject.AddComponent<AudioSource>();
        
    }
    void Introduce()
    {
        AudioManager.GetInstance().PlaySfx("��");
        currentTuto = "Introduce";
        Dirtxt.text = "PLANTAREA�� ���������� �̿��� ������ ���� ���� ������ �Ĺ��� �⸦ �� �ִ� ���̾�. ���� ��ɿ� ���� �˾ƺ���?";
        NextBtnChange();
    }

    void BottomTutoBtn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        Dirtxt.text = "ȭ�� �Ʒ��� �Ĺ� ���� ���� ��ư���̾�. ������ ��ư�� ������!";
        BottomStep();
    }
    void RightTutoBtn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(true);
        Dirtxt.text = "ȭ�� �������� ������ ���� ��ư���̾�. ���� ��ư�� ������!";
        NextBtn.gameObject.SetActive(false);
        RightStep();
    }
    void TopTutoBtn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(true);
        Dirtxt.text = "ȭ�� ������ �÷��̾� ���� â���̾�. ������ ������ Ȯ����!";
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
                AudioManager.GetInstance().PlaySfx("���");
            

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
            AudioManager.GetInstance().PlaySfx("���");

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
            AudioManager.GetInstance().PlaySfx("���");

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
        
        NextBtnChange();
        string[,] txtList = new string[,]
        { { "���Ѹ����� �̿��� �Ĺ��� ���� �� �� �־��. ���е��� �ʹ� ���ų� ������ �Ĺ��� ������ �����ϼ���!", "��", "CryStr"},
        {"�������� �̿��� �Ĺ��� ������ �� �� �־��. ���絵�� �ʹ� ���ų� ������ �Ĺ��� ������ �ɸ��ϴ�.","������", "SadStr"},
        { "Ī���� �Ϸ翡 1ȸ �����մϴ�. Ī������ �Ĺ��� ���絵�� ���е��� ���� �÷��ݴϴ�.","Growth2","SmileTalkStr"},
        {"����â�Դϴ�. �Ĺ��� ���¸� Ȯ���� �� �ְ� �Ĺ��� �̸�,�޸� ���� �� �ִ� â�̴� ���� Ȯ���غ�����!" ,"å","SmileStr"}};

        string v = txtList[index, 0].ToString();
        Dirtxt.text = v;
        AudioManager.GetInstance().PlaySfx($"{txtList[index,1]}");
        Character.sprite = Resources.Load<Sprite>($"Character/{txtList[index, 2]}");

    }
    void RightSetBtn(int index)
    {
        currentTuto = "Right";
        NextBtntxt.text = "����";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        
        NextBtnChange();
        string[,] txtList = new string[,]
        { { "ȭ�п� ������ ���� �� �ֽ��ϴ�. ������ ���۹��� ��������� �����ϴ�. ���ϴ� ������ �ɾ����!","��","SmileTalk" },
        { "�������� ����, ���� �� �������� �����غ�����! �Ĺ��� Ű��� �� ������ �˴ϴ�.","Buy2","TalkStr" },
        { "Ű��� �Ĺ��� ������ �������� Ȯ���غ�����! ��� �Ĺ��� ȹ���� ������ ��� ��ƺ�����!","å����","SmileTalkStr"},
        {"�κ��丮 â���� ������ �ִ� �������� Ȯ���� �� �ֽ��ϴ�.","��","Smile2"}};

        string v = txtList[index,0].ToString();
        Dirtxt.text = v;
        AudioManager.GetInstance().PlaySfx($"{txtList[index, 1]}");
        Character.sprite = Resources.Load<Sprite>($"Character/{txtList[index,2]}");
    }
    void TopSetBtn(int index)
    {
        currentTuto = "Top";
        NextBtntxt.text = "��������";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        NextBtnChange();
        string[,] txtList = new string[,]
        { { "���� ������ �ð��� �� �� �ֽ��ϴ�." ,"��", "SmileTalk" },
        {"���� �÷��̾��� ����Դϴ�. �ൿ���� ����� �Ҹ��ϰ� ����� �����ϸ� �ൿ�� �� �� �����ϴ�.","Growth1" ,"SmileStr"},
        { "�������� ��� ������ ����Դϴ�. �ý��� ������ �ްų� �������� �Ⱦ� ȹ�� �����մϴ�.", "Buy2","TalkStr"} };

        string v = txtList[index,0].ToString();
        Dirtxt.text = v;
        AudioManager.GetInstance().PlaySfx($"{txtList[index, 1]}");
        Character.sprite = Resources.Load<Sprite>($"Character/{txtList[index, 2]}");
    }
    void ToMainBtn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        Dirtxt.text = "��! ���� �⺻���ΰ� �˷������� �� ģ���鵵 �� �⸦ �� ����? " +
            "������ �ʿ��ϸ� �������� �ɼ��� ������ ������!";
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

