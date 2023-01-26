using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        volume = 0.3f;
        loop = _loop;
    }

}

public enum SoundGenre
{
    Bgm,
    Sfx
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

    AudioSource soundPlayer;

    public Dictionary<SoundGenre, Sound> sounds = new Dictionary<SoundGenre, Sound>();




    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        soundPlayer = GetComponent<AudioSource>();
        InitSounds();

    }

    public void InitSounds()
    {
        AudioClip[] bgm = Resources.LoadAll<AudioClip>($"Sound/Bgm");
        AudioClip[] sfx = Resources.LoadAll<AudioClip>($"Sound/SFX");
        
        for(int i = 0; i<bgm.Length; i++)
        {
            sounds.Add(SoundGenre.Bgm, new Sound(bgm[i].name, bgm[i], false));
        }
        

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

