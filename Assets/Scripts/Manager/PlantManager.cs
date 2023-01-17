using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class PlantManager : MonoBehaviour
{
    #region SingletoneMake
    public static PlantManager instance = null;
    public static PlantManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@PlantManager");
            instance = go.AddComponent<PlantManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion
 
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    GameObject spawnablePrefab;
    GameObject spawnedObject;

    public PlantBase[] plantDates = new PlantBase[]
    {
        
    };

    void Start()
    {
        spawnedObject = null;
    }


    void Update()
    {
        if (Input.touchCount == 0)
            return;
        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SpawnPrefab(m_Hits[0].pose.position);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }

    }

    public void SpawnPrefab(Vector3 spawnPosition)
    {
        int ran = Random.Range(1, 6);
        Object ob = Resources.Load($"plant{ran}");
        spawnedObject = (GameObject)Instantiate(ob, spawnPosition, Quaternion.identity);
        spawnedObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void EraseSpawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
