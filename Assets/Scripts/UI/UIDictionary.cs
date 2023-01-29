using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDictionary : MonoBehaviour
{
    [Header("Standard Dictionary")]
    [SerializeField] Button btnCloseDict;
    [SerializeField] InputField inputSearch;
    [SerializeField] Button btnSearch;
    [SerializeField] Button btnPrev;
    [SerializeField] Button btnNext;

    [Header("Plant List")]
    [SerializeField] Button[] btnPlantList;
    [SerializeField] Text[] txtIPlantList;

    [Header("Plant Detail")]
    [SerializeField] GameObject plantDetail;
    [SerializeField] Image imgPlant;
    [SerializeField] Text txtPlantName;
    [SerializeField] Text txtPlantKind;
    [SerializeField] Text txtPlantClass;
    [SerializeField] Text txtPlantInfo;
    [SerializeField] Button btnCloseDetail;



    GameManager gamemanager;
    PlantManager plantmanager;
    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.GetInstance();
        plantmanager = PlantManager.GetInstance();
        uimanager = UIManager.GetInstance();
        SetButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetButton()
    {
        btnCloseDict.onClick.AddListener(OnClickCloseDict);
        btnCloseDetail.onClick.AddListener(OnClickCloseDetail);
        OnClickDetail();
    }


    private void OnClickCloseDict()
    {
        gameObject.SetActive(false);
    }

    private void OnClickCloseDetail()
    {
        plantDetail.gameObject.SetActive(false);
    }

    private void OnClickDetail()
    {
        for(int i = 0; i<btnPlantList.Length; i++)
        {
            int idx = i;
            btnPlantList[i].onClick.AddListener(OnClickDetailOpen);
        }
    }

    private void OnClickDetailOpen()
    {
        plantDetail.gameObject.SetActive(true);
    }
}
