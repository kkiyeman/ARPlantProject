using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.InteractiveTutorials;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    [Header("��� ����")]
    [SerializeField] GameObject bottomSide;
    [SerializeField] GameObject topSide;
    [SerializeField] GameObject rightSide;
    [SerializeField] GameObject status;

    [Header("����")]
    [SerializeField] Image[] Arrows;
    [SerializeField] Button[] BottomBtnList;

    [Header("�߾�")]
    [SerializeField] Button NextBtn;
    [SerializeField] Text Dirtxt;
    [SerializeField] Text NextBtntxt;
    [SerializeField] Image Character;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        NextBtntxt.text = "����";
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        topSide.gameObject.SetActive(false);
        Dirtxt.text = "���� ��ư�� ���� Ʃ�丮���� �����ϼ���!";
        NextBtn.onClick.AddListener(BottomTutoBtn);

    }

    void BottomTutoBtn()
    {
        Dirtxt.text = "ȭ�� �Ʒ��� �Ĺ� ���� ���� ��ư���Դϴ�. ��ư�� ����������!";
        Step1();
    }
    void RightTutoBtn()
    {
        Dirtxt.text = "ȭ�� �������� ���� �������̽� ���� ��ư���Դϴ�. ��ư�� ����������!";
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
                Debug.Log("��ư ���� �Ϸ�");
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
        NextBtntxt.text = "�ǳʶٱ�";
        NextBtn.gameObject.SetActive(true);
        NextBtn.onClick.RemoveAllListeners();
        NextBtn.onClick.AddListener(RightTutoBtnOn);
        string[] txtList = new string[]
        { "���Ѹ����� �̿��� �Ĺ��� ���� �� �� �־��. ���е��� �ʹ� ���ų� ������ �Ĺ��� ������ �����ϼ���!" ,
        "�������� �̿��� �Ĺ��� ������ �� �� �־��. ���絵�� �ʹ� ���ų� ������ �Ĺ��� ������ �ɸ��ϴ�.",
        "Ī���� �Ϸ翡 1ȸ �����մϴ�. Ī������ �Ĺ��� ���絵�� ���е��� ���� �÷��ݴϴ�.",
        "ȭ�п� ������ ���� �� �ֽ��ϴ�. ������ ���۹��� ��������� �����ϴ�. ���ϴ� ������ �ɾ����!" };

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
