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

    // Update is called once per frame
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
        curPlantName = "";
        CloseUI();
    }

    private void OnClickApply()
    {
        curPlantName = inputPlantName.text;
        Invoke("CloseUI", 1.5f);
        //gameObject.SetActive(false);

        SpawnMyPlant();
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

    private void SpawnMyPlant()
    {
        MyPlantManager myPlantManager = MyPlantManager.GetInstance();
        potTrans = plantmanager.potTrans;
        plantName = plantmanager.plantDates[plantmanager.clickIdx].plantName;
        var seed = Resources.Load<GameObject>($"plant/{plantName}/Seed");
        //var seed = Resources.Load<GameObject>($"plant/Seed");
        var Plant = Instantiate(seed, potTrans);

        MyPlantList myPlant = Plant.GetComponent<MyPlantList>();

        myPlantManager.myPlantList.Add(myPlant);
    }
}
