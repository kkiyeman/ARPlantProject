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

    PlantManager plantmanager;

    void Start()
    {
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
    }

    private void CloseUI()
    {
        inputPlantName.text = "";
        txtNewPlantName.text = "";
        gameObject.SetActive(false);
    }
}
