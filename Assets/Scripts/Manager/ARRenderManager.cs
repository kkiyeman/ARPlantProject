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

    void Start()
    {
        ARSO = FindObjectOfType<ARSessionOrigin>();
        ARPM = ARSO.GetComponent<ARPlaneManager>();
        ARRM = ARSO.GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaneOff()
    {
        ARRM.enabled = false;
        ARPM.enabled = false;
    }
}
