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


    public Sound(string _name, AudioClip _clip, AudioSource _source, float _volume, bool _loop)
    {
        name = _name;
        clip = _clip;

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
    
    public 




    void Start()
    {


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

    public void InitBgmSfx()
    {

    }


}

