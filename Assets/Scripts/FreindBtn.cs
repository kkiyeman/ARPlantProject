using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreindBtn : MonoBehaviour
{
    private Button btn;

    [SerializeField]
    private GameObject friendTitleContainer;
    [SerializeField] 
    private GameObject friendContainer;

    [SerializeField]
    private Color activeColor;
    [SerializeField]
    private Color disableColor;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickFriendToggleBtn);

        activeColor = btn.image.color;
    }

    void OnClickFriendToggleBtn() 
    {
        bool active = friendContainer.activeSelf;
        friendContainer.SetActive(!active);
        friendTitleContainer.SetActive(!active);

        btn.image.color = active ? activeColor : disableColor;
    }
}