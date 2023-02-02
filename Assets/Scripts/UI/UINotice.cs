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
    int LoginPresentMoney =100;

    public GameObject NoticePanal;

    public List<MyPlantList> myPlantList = new List<MyPlantList>();
    // Start is called before the first frame update
    void Start()
    {
        WelcomeNotice();
      OkBtn.onClick.AddListener(OkNoticeBtn);
    }

    public void DieNotice(string name)
    {
        rewardImg.gameObject.SetActive(false);
        rewardtxt.gameObject.SetActive(false);
        Character.sprite = Resources.Load<Sprite>("Character/CryStr");
        Noticetxt.text = $"�װ� ���� ���̿� �츮 {name}�� �װ� ���Ҿ�..! ���ο� �Ĺ��� Ű��� �ʹٸ� ������ �ٽ� �ɾ��.";
        NoticePanal.SetActive(true);
    }
    public void GrowthNotice(string name)
    {
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
        Character.sprite = Resources.Load<Sprite>("Character/SadStr");
        rewardImg.gameObject.SetActive(false);
        rewardtxt.gameObject.SetActive(false);
        NoticePanal.SetActive(true);
        Noticetxt.text = $"ū���̾�! �츮 {name}�� ����..! ����â�� Ȯ������Ф�";
    }
    public void WelcomeNotice()
    {
        rewardImg.gameObject.SetActive(true);
        rewardtxt.gameObject.SetActive(true);
        rewardtxt.text = $"+{LoginPresentMoney}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Icon_Money");
        NoticePanal.SetActive(true);
        Noticetxt.text = $"���~ ���� �Ϸ�� �? �츰 ���⼭ �� ��ٸ��� �־���! ���� ������?";

    }
    public void OkNoticeBtn()
    {
        NoticePanal.gameObject.SetActive(false);
    }
}
