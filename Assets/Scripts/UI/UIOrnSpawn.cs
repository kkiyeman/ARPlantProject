using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrnSpawn : MonoBehaviour
{
    [SerializeField] Button btnCloseUI;
    public Button[] ornSpawn;
    public int idx;

    UIManager uimanager;

    private void Start()
    {
        uimanager = UIManager.GetInstance();
        SetButton();
    }

    private void Update()
    {
        
    }

    private void SetButton()
    {
        btnCloseUI.onClick.AddListener(OnClickCloseUI);

        for (int i = 0; i < ornSpawn.Length; i++)
        {
            int idx = i;
            ornSpawn[i].onClick.AddListener(() => {
                SelectOrnSpawn(idx);
            });
        }
    }

    private void OnClickCloseUI()
    {
        gameObject.SetActive(false);
    }

    private void OnClickOpenUI()
    {
        var uiInputName = uimanager.GetUI("UIInputPlantName");
        uiInputName.gameObject.SetActive(true);
    }

    public void SelectOrnSpawn(int idx)
    {
        this.idx = idx;
        OnClickOpenUI();
        PlantManager.GetInstance().SetIdx(idx);
    }
}
