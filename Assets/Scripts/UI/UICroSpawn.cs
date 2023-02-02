using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICroSpawn : MonoBehaviour
{
    [SerializeField] Button btnCloseUI;
    public Button[] croSpawn;
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

        for (int i = 0; i < croSpawn.Length; i++)
        {
            int idx = i + 4;
            croSpawn[i].onClick.AddListener(()=> {                
                SelectCroSpawn(idx);
            });
        }
    }

    private void OnClickCloseUI()
    {
        AudioManager.GetInstance().PlaySfx("»Ð");
        gameObject.SetActive(false);
    }

    private void OnClickOpenUI()
    {
        AudioManager.GetInstance().PlaySfx("»Ð");
        var uiInputName = uimanager.GetUI("UIInputPlantName");
        uiInputName.gameObject.SetActive(true);
    }

    public void SelectCroSpawn(int idx)
    {
        this.idx = idx;
        OnClickOpenUI();
        PlantManager.GetInstance().SetIdx(idx);
    }
}
