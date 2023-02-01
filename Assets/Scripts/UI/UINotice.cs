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

    PlantManager plantManager;
    MyPlantManager myPlantManager;
    GameManager gameManager;
    GameObject NoticePanal;

    public List<MyPlantList> myPlantList = new List<MyPlantList>();
    int index;
    // Start is called before the first frame update
    void Start()
    {
      OkBtn.onClick.AddListener(OkNoticeBtn);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrowPlant();
        CheckDiePlant();
    }

    void CheckGrowPlant()
    {
       /* if (myPlantList[idx].growthRate >= 100)
        {
            GrowthNotice();
            MyPlantList[idx].growthRate = 0;
        }*/
    }

    void CheckDiePlant()
    {
        /*if (MyPlantManager.GetInstance().DieThePlant)
        {
            DieNotice();
        }*/
    }
    public void DieNotice()
    {
        NoticePanal.SetActive(true);
        Noticetxt.text = $"네가 없던 사이에 우리 {index}가 죽고 말았어..! 새로운 식물을 키우고 싶다면 씨앗을 다시 심어보자.";
    }
    public void GrowthNotice()
    {
        rewardtxt.text = $"+{myPlantManager.GrowPlantReward}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Icon_Money");
        gameManager.curGameMoney = myPlantManager.GrowPlantReward++;
        NoticePanal.SetActive(true);
        Noticetxt.text = $"와!{index}이 멋지게 성장했어! 앞으로 더욱 애정을 담아서 길러줘!";
    }
    void OkNoticeBtn()
    {
        NoticePanal.gameObject.SetActive(false);
    }
}
