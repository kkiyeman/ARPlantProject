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
        AudioManager.GetInstance().PlaySfx("띠딩");
        rewardImg.gameObject.SetActive(false);
        rewardtxt.gameObject.SetActive(false);
        Character.sprite = Resources.Load<Sprite>("Character/CryStr");
        Noticetxt.text = $"네가 없던 사이에 우리 {name}가 죽고 말았어..! 새로운 식물을 키우고 싶다면 씨앗을 다시 심어보자.";
        NoticePanal.SetActive(true);
    }
    public void GrowthNotice(string name)
    {
        AudioManager.GetInstance().PlaySfx("띠딩");
        rewardImg.gameObject.SetActive(true);
        rewardtxt.gameObject.SetActive(true);
        Character.sprite = Resources.Load<Sprite>("Character/SmileTalk");
        rewardtxt.text = $"+{myPlantManager.GrowPlantReward}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Gem");
        NoticePanal.SetActive(true);
        Noticetxt.text = $"와!{name}이 멋지게 성장했어! 앞으로 더욱 애정을 담아서 길러줘!";
    }
    public void DiseaseNotice(string name)
    {
        AudioManager.GetInstance().PlaySfx("띠딩");
        Character.sprite = Resources.Load<Sprite>("Character/SadStr");
        rewardImg.gameObject.SetActive(false);
        rewardtxt.gameObject.SetActive(false);
        NoticePanal.SetActive(true);
        Noticetxt.text = $"큰일이야! 우리 {name}가 아파..! 상태창을 확인해줘ㅠㅠ";
    }
    public void WelcomeNotice()
    {
        AudioManager.GetInstance().PlaySfx("띠딩");
        rewardImg.gameObject.SetActive(true);
        rewardtxt.gameObject.SetActive(true);
        rewardtxt.text = $"+{LoginPresentMoney}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Icon_Money");
        NoticePanal.SetActive(true);
        Noticetxt.text = $"어서와~ 오늘 하루는 어때? 우린 여기서 널 기다리고 있었어! 이제 가볼까?";

    }
    public void OkNoticeBtn()
    {
        AudioManager.GetInstance().PlaySfx("뿅");
        NoticePanal.gameObject.SetActive(false);
    }
    public void WaterNotice()
    { 
    
    }

}
