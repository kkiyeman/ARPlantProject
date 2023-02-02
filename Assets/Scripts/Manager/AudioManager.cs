using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;

    public float volume;
    public bool loop = true;
    

    public Sound(string _name,  AudioClip _clip , bool _loop)
    {
        name = _name;
        clip = _clip;
        volume = 0.1f;
        loop = _loop;
    }

}

public class AudioManager : MonoBehaviour
{

    #region SingletoneMake
    public static AudioManager instance = null;
    public static AudioManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@AudioManager");
            instance = go.AddComponent<AudioManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    public AudioSource BgmPlayer;
    public AudioSource SfxPlayer;
    public Dictionary<string, Sound> bgms = new Dictionary<string, Sound>();
    public Dictionary<string, Sound> sfxs = new Dictionary<string, Sound>();
    public AudioMixer audioMixer;
    public UIOption uiOption;
    UIManager uiManager;

    void Awake()
    {
        uiManager = UIManager.GetInstance();
        var ob1 = new GameObject();
        ob1.name = "@BgmPlayer";
        var ob2 = new GameObject();
        ob2.name = "@SfxPlayer";
        ob1.transform.SetParent(gameObject.transform);
        ob2.transform.SetParent(gameObject.transform);
        ob1.AddComponent<AudioSource>();
        ob2.AddComponent<AudioSource>();
        BgmPlayer = ob1.GetComponent<AudioSource>();
        SfxPlayer = ob2.GetComponent<AudioSource>();       
        InitSounds();
        
    }

    public void InitSounds()
    {
        AudioClip[] bgm = Resources.LoadAll<AudioClip>($"Sound/Bgm");
        AudioClip[] sfx = Resources.LoadAll<AudioClip>($"Sound/SFX");
        
        for(int i = 0; i<bgm.Length; i++)
        {
            bgms.Add(bgm[i].name , new Sound(bgm[i].name, bgm[i], false));
        }

        for(int j = 0; j<sfx.Length; j++)
        {
            sfxs.Add(sfx[j].name , new Sound(sfx[j].name, sfx[j], false));
        }
        

    }

    public void PlayBgm(string name)
    {
        

        Debug.Log("isPlaying : " + SfxPlayer.isPlaying);
        var bgm = bgms[name];
        bgm.loop = true;
        BgmPlayer.clip = bgm.clip;
        BgmPlayer.volume = bgm.volume = 0.1f;
        BgmPlayer.loop = bgm.loop;
        BgmPlayer.Play();
    }
    
    public void PlaySfx(string name)
    {
        var sfx = sfxs[name];
        SfxPlayer.clip = sfx.clip;
        SfxPlayer.volume = sfx.volume = 0.3f;
        SfxPlayer.loop = sfx.loop;
        SfxPlayer.Play();

        /*uiOption = uiManager.GetUI("UIOption").GetComponent<UIOption>();
        uiOption.SetSFXVolme(sfx.volume);*/

    }
    




    //public void SfxPlay(string s)
    //{
    //    for (int i = 0; i < sfx.Length; i++)
    //    {
    //        if (s == sfx[i].name)
    //        {
    //            sfx[i].Play();
    //            return;
    //        }
    //    }
    //}

    //public void SfxStop(string s)
    //{
    //    for (int i = 0; i < sfx.Length; i++)
    //    {
    //        if (s == sfx[i].name)
    //        {
    //            sfx[i].Stop();
    //            return;
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

    }




}

