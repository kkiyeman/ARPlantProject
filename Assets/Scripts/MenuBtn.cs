using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBtn : MonoBehaviour
{
    Button btn;
    
    [SerializeField] 
    Animation menuAnimation;

    [SerializeField]
    Button btnDim;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OpenMenu);
        btnDim.onClick.AddListener(CloseMenu);
    }

    void OpenMenu()
    {
        btnDim.gameObject.SetActive(true);
        menuAnimation.Stop();
        menuAnimation.Play("Open");
    }

    void CloseMenu()
    {
        btnDim.gameObject.SetActive(false);
        menuAnimation.Stop();
        menuAnimation.Play("Close");
    }
}
