using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    public Button SkipBtn;
    ScenesManager sM;
    // Start is called before the first frame update
    void Start()
    {
      sM = GetComponent<ScenesManager>();
      SkipBtn = GetComponent<Button>();
      SkipBtn.onClick.AddListener(OnClickStart);
    }
    void OnClickStart()
    {      
        sM.ChangeScene(Scene.Plant);
    }
}
