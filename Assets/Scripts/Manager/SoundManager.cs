using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BgmSound;
    public AudioClip[] SoundClips;

    #region SingletoneMake
    public static SoundManager instance = null;
    public static SoundManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@SoundManager");
            instance = go.AddComponent<SoundManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion
    /*#region SoundControl
    Dictionary<string, GameObject> BgmList = new Dictionary<string, GameObject>();
    public void OpenBgm(string BgmName)
    {
        if (BgmList.ContainsKey(BgmName) == false)
        {
            Object uiObj = Resources.Load($"Sound/Bgm/{BgmName}");
            GameObject go = (GameObject)Instantiate(uiObj);
            BgmList.Add(BgmName, go);
        }
        else
        {
            BgmList[BgmName].SetActive(true);
        }

    }

    public void OpenStaticBgm(string BgmName)
    {
        if (BgmList.ContainsKey(BgmName) == false)
        {
            Object uiObj = Resources.Load($"Sound/Bgm/{BgmName}");
            GameObject go = (GameObject)Instantiate(uiObj);
            DontDestroyOnLoad(go);
            BgmList.Add(BgmName, go);
        }
        else
        {
            BgmList[BgmName].SetActive(true);
        }

    }

    public void CloseBgm(string BgmName)
    {
        if (BgmList.ContainsKey(BgmName))
        {
            BgmList[BgmName].SetActive(false);
        }

    }

    public GameObject GetUI(string BgmName)
    {

        if (BgmList.ContainsKey(BgmName))
            return BgmList[BgmName];
        return null;
    }*/
    public void BgmSoundPlay(AudioClip clip)
    {
        BgmSound.clip = clip;
        BgmSound.loop = true;
        BgmSound.volume = 0.1f;
        BgmSound.Play();
    }

   /* public void ClearList()
    {
        BgmList.Clear();
    }
#endregion*/
}
