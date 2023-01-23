using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;
    private AudioSource source;

    public float volume;
    public bool loop = true;

    public void SetSource(AudioSource _sound)
    {
        source = _sound;
        source.clip = clip;
        source.loop = loop;
        source.volume = 0.3f;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void SetLoop()
    {
        source.loop = true;
    }

    public void SetLoopCancel()
    {
        source.loop = false;
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
    
    [SerializeField]
    public Sound[] bgm;
    [SerializeField]
    public Sound[] sfx;

    public void SetSound()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            GameObject bgmObject = new GameObject("bgm 파일 이름 : " + i + " = " + bgm[i].name);
            bgm[i].SetSource(bgmObject.AddComponent<AudioSource>());
            bgmObject.transform.SetParent(this.transform);
        }
        for (int i = 0; i < sfx.Length; i++)
        {
            GameObject sfxObject = new GameObject("sfx 파일 이름 : " + i + " = " + sfx[i].name);
            sfx[i].SetSource(sfxObject.AddComponent<AudioSource>());
            sfxObject.transform.SetParent(this.transform);
        }
    }
    //Start is called before the first frame update
    void Start()
    {


    }

    public void BgmPlay(int a)
    {
        bgm[a].Play();

    }

    public void BgmStop(int a)
    {
        bgm[a].Stop();
    }



    public void SfxPlay(string s)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (s == sfx[i].name)
            {
                sfx[i].Play();
                return;
            }
        }
    }

    public void SfxStop(string s)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (s == sfx[i].name)
            {
                sfx[i].Stop();
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitBgmSfx()
    {

    }


}

