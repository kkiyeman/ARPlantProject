using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class ARRenderManager : MonoBehaviour
{
    #region SingletoneMake
    public static ARRenderManager instance = null;
    public static ARRenderManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ARRenderManager");
            instance = go.AddComponent<ARRenderManager>();

        }
        return instance;
    }
    #endregion


    public ARSessionOrigin ARSO;
    public ARPlaneManager ARPM;
    public ARRaycastManager ARRM;
    public ARPointCloudManager ARPCM;
    void Start()
    {
        ARSO = FindObjectOfType<ARSessionOrigin>();
        ARPM = ARSO.GetComponent<ARPlaneManager>();
        ARRM = ARSO.GetComponent<ARRaycastManager>();
        ARPCM = ARSO.GetComponent<ARPointCloudManager>();
        ARRM.enabled = false;
        ARPM.enabled = false;
        ARPCM.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // AR 플레인 안보이게 만들기
    public void PlaneOff()
    {
        ARRM.enabled = false;
        ARPM.enabled = false;
        ARPCM.enabled = false;
        foreach (var plane in ARPM.trackables) //ARPM.trackables라는 데이터 값들을 plane을 넣고 
        {
            plane.gameObject.SetActive(false); // 플레인의 게임오브젝트를 비활성화
        }

        foreach (var poincloud in ARPCM.trackables) // 위와 동일
        {
            poincloud.gameObject.SetActive(false); //
        }
    }

    public void PlaneOn()
    {

        ARRM.enabled = true;
        ARPM.enabled = true;
        ARPCM.enabled = true;
    }
}
