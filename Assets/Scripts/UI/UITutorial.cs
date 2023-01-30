using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    public Button bottomOnbtn;
    public Button topOnbtn;
    public Button rightOnbtn;
    public Button WatertutoBtn;
    public Button NutritutoBtn;
    public Button CommenttutoBtn;
    public Button SeedtutoBtn;

    public Image bottomSide;
    public Image topSide;
    public Image rightSide;
    public Image status;

    public AudioSource[] NarList;
    public AudioSource Nar1;

    public AudioClip[] NarclipList;
    public AudioClip NarClip1;
    public AudioClip NarClip2;
    
    // Start is called before the first frame update
    void Start()
    {
        bottomOnbtn.onClick.AddListener(BottomTutoBtn);
        rightOnbtn.onClick.AddListener(RightTutoBtn);
        topOnbtn.onClick.AddListener(TopTutoBtn);
    }

    void BottomTutoBtn()
    {
        status.gameObject.SetActive(false);
        bottomSide.gameObject.SetActive(true); 
        topSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
    }
    void RightTutoBtn()
    {
        rightSide.gameObject.SetActive(true);  
        topSide.gameObject.SetActive(false);
        bottomSide.gameObject.SetActive(false);
    }
    void TopTutoBtn()
    {
        topSide.gameObject.SetActive(true);
        bottomSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
    }
    IEnumerator BottomTuto()
    {
        Nar1.clip = NarClip1;
        Nar1.Play();
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!Nar1.isPlaying)
            {
                WatertutoBtn.gameObject.SetActive(true);
                
                /*Nar1.clip = NarClip2;
                Nar1.Play();
                Nar1.loop = true; */

            }

        }
    }
}
