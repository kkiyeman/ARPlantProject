using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICroSpawn : MonoBehaviour
{
    [SerializeField] Button btnCloseUI;
    public GameObject[] croSpawn;

    private void Start()
    {
        SetButton();
    }

    private void Update()
    {

    }

    private void SetButton()
    {
        btnCloseUI.onClick.AddListener(OnClickCloseUI);
    }

    private void OnClickCloseUI()
    {
        gameObject.SetActive(false);
    }
}
