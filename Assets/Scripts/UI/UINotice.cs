using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINotice : MonoBehaviour
{
    [SerializeField] Image rewardImg;
    [SerializeField] Text rewardtxt;
    [SerializeField] Text Noticetxt;
    [SerializeField] Button OkBtn;
    [SerializeField] Image Character;

    PlantManager plantManager;
    MyPlantManager myPlantManager;
    GameManager gameManager;
    int LoginPresentMoney = 1000;

    public GameObject NoticePanal;

    public List<MyPlantList> myPlantList = new List<MyPlantList>();

    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.GetInstance();
        WelcomeNotice();
      OkBtn.onClick.AddListener(OkNoticeBtn);
        gamemanager.curGameMoney += LoginPresentMoney;
    }

    public void DieNotice(string name)
    {
        AudioManager.GetInstance().PlaySfx("���");
        rewardImg.gameObject.SetActive(false);
        rewardtxt.gameObject.SetActive(false);
        Character.sprite = Resources.Load<Sprite>("Character/CryStr");
        Noticetxt.text = $"�װ� ���� ���̿� �츮 {name}�� �װ� ���Ҿ�..! ���ο� �Ĺ��� Ű��� �ʹٸ� ������ �ٽ� �ɾ��.";
        NoticePanal.SetActive(true);
    }
    public void GrowthNotice(string name)
    {
        AudioManager.GetInstance().PlaySfx("���");
        rewardImg.gameObject.SetActive(true);
        rewardtxt.gameObject.SetActive(true);
        Character.sprite = Resources.Load<Sprite>("Character/SmileTalk");
        rewardtxt.text = $"+{myPlantManager.GrowPlantReward}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Gem");
        NoticePanal.SetActive(true);
        Noticetxt.text = $"��!{name}�� ������ �����߾�! ������ ���� ������ ��Ƽ� �淯��!";
    }
    public void DiseaseNotice(string name)
    {
        AudioManager.GetInstance().PlaySfx("���");
        Character.sprite = Resources.Load<Sprite>("Character/SadStr");
        rewardImg.gameObject.SetActive(false);
        rewardtxt.gameObject.SetActive(false);
        NoticePanal.SetActive(true);
        Noticetxt.text = $"ū���̾�! �츮 {name}�� ����..! ����â�� Ȯ������Ф�";
    }
    public void WelcomeNotice()
    {
        AudioManager.GetInstance().PlaySfx("���");
        rewardImg.gameObject.SetActive(true);
        rewardtxt.gameObject.SetActive(true);
        rewardtxt.text = $"+{LoginPresentMoney}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Icon_Money");
        NoticePanal.SetActive(true);
        Noticetxt.text = $"���~ ���� �Ϸ�� �? �츰 ���⼭ �� ��ٸ��� �־���! ���� ������?";

    }
    public void OkNoticeBtn()
    {
        AudioManager.GetInstance().PlaySfx("��");
        NoticePanal.gameObject.SetActive(false);
    }
    public void WaterNotice()
    { 
    
    }

}
