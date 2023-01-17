using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Start,
    Plant,
}
public class ScenesManager : MonoBehaviour
{
    #region SingletoneMake
    public static ScenesManager instance = null;
    public static ScenesManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ScenesManager");
            instance = go.AddComponent<ScenesManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion
    #region Scene Control
    public Scene currentScene;
    public void ChangeScene(Scene scene)
    {
        UIManager.GetInstance().ClearList(); // ���� �ٲ𶧸��� UI�Ŵ����� Ŭ�������ְڴ�.
                                         // PrevScene = currentScene;
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());

    }
    #endregion
}
