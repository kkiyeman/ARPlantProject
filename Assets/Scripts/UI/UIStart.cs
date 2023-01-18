using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    public Button SkipBtn;
    ScenesManager sM;
   
    void Start()
    {
      sM = ScenesManager.GetInstance();
      SkipBtn.onClick.AddListener(OnClickStart);
    }
    void OnClickStart()
    {
        SceneManager.LoadScene("Plant");
    }
}
