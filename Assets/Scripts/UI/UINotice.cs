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
    // Start is called before the first frame update
    void Start()
    {
      OkBtn.onClick.AddListener(OkNoticeBtn);
    }

    public void DieNotice(string name)
    {
        NoticePanal.SetActive(true);
        Noticetxt.text = $"�װ� ���� ���̿� �츮 {name}�� �װ� ���Ҿ�..! ���ο� �Ĺ��� Ű��� �ʹٸ� ������ �ٽ� �ɾ��.";
    }
    public void GrowthNotice(string name)
    {
        rewardtxt.text = $"+{myPlantManager.GrowPlantReward}";
        rewardImg.sprite = Resources.Load<Sprite>("Icon/Store/Icon_Money");
        gameManager.curGameMoney = myPlantManager.GrowPlantReward++;
        NoticePanal.SetActive(true);
        Noticetxt.text = $"��!{name}�� ������ �����߾�! ������ ���� ������ ��Ƽ� �淯��!";
    }
    public void DiseaseNotice(string name)
    {
        NoticePanal.SetActive(true);
        Noticetxt.text = $"ū���̾�! �츮 {name}�� ����..! ����â�� Ȯ������Ф�";
    }
    public void OkNoticeBtn()
    {
        NoticePanal.gameObject.SetActive(false);
    }
}
