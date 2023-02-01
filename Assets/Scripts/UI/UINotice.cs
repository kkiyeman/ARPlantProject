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
        Noticetxt.text = $"�װ� ���� ���̿� �츮 {index}�� �װ� ���Ҿ�..! ���ο� �Ĺ��� Ű��� �ʹٸ� ������ �ٽ� �ɾ��.";
    }
    public void GrowthNotice()
    {
        rewardtxt.text = $"+{myPlantManager.GrowPlantReward}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Icon_Money");
        gameManager.curGameMoney = myPlantManager.GrowPlantReward++;
        NoticePanal.SetActive(true);
        Noticetxt.text = $"��!{index}�� ������ �����߾�! ������ ���� ������ ��Ƽ� �淯��!";
    }
    void OkNoticeBtn()
    {
        NoticePanal.gameObject.SetActive(false);
    }
}
