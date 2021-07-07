using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boyfriend : MonoBehaviour
{
    public MusicConduct mc;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator Handle;
    public Slider Healthbar;
    private bool PlayerDead = false;
    public AudioSource DyingSource;
    public AudioClip[] DyingSounds;

    private int m_MyVar = 0;
    public int myVar = 0; //Gets the int value for BobInt, which assigns it's value on the songPositionInBeats float for MusicConduct

    private void Update() {
        myVar = mc.BobInt;
        
        if (m_MyVar < myVar && this.anim.GetCurrentAnimatorStateInfo(0).IsName("BF idle dance"))
        {
            PlayIdle();
            m_MyVar = myVar;
        }

        if (Healthbar.value >= 0 && PlayerDead == false)
        {
            anim.Play("BF Dead Loop");
            //anim.transform.localPosition = new Vector3(0f, -1f, 0f);
            PlayerDead = true;
            DyingSource.clip = DyingSounds[0];
            DyingSource.Play();
        }
        if(PlayerDead && !DyingSource.isPlaying)
        {
            DyingSource.clip = DyingSounds[1];
            DyingSource.Play();
        }
    }

    void PlayIdle()
    {
        anim.Play("BF idle dance", -1, 0f);
        Handle.Play("HandleBump", -1, 0f);
    }
}

