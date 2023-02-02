using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputPlantName : MonoBehaviour
{
    public string curPlantName = "";
    [SerializeField] Text txtNewPlantName;
    [SerializeField] InputField inputPlantName;
    [SerializeField] Button btnCancel;
    [SerializeField] Button btnApply;

    [HideInInspector] public Transform potTrans;

    PlantManager plantmanager;
    UIManager uimanager;

    public string plantName = "";

    void Start()
    {
        uimanager = UIManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        SetButton();
    }

    void Update()
    {
        
    }

    private void SetButton()
    {
        btnCancel.onClick.AddListener(OnClickCancel);
        btnApply.onClick.AddListener(OnClickApply);
    }

    private void OnClickCancel()
    {
        AudioManager.GetInstance().PlaySfx("»Ð");
        curPlantName = "";
        CloseUI();
    }

    private void OnClickApply()
    {
        AudioManager.GetInstance().PlaySfx("»Ð");
        curPlantName = inputPlantName.text;
        plantmanager.setPlantUserName = curPlantName;

        potTrans = plantmanager.potTrans;

        //plantmanager.SetPlantInfo(plantmanager.clickIdx);
        Invoke("CloseUI", 1.5f);
        //gameObject.SetActive(false);

        plantmanager.SpawnMyPlant(plantName);
    }

    private void CloseUI()
    {
        inputPlantName.text = "";
        txtNewPlantName.text = "";
        gameObject.SetActive(false);

        var SpawnOrn = uimanager.GetUI("UIOrnSpawn");
        SpawnOrn.SetActive(false);

        var SpawnCro = uimanager.GetUI("UICroSpawn");
        SpawnCro.SetActive(false);
    }

}
