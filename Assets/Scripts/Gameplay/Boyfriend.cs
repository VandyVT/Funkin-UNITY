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
        
        if (m_MyVar < myVar && this.anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))
        {
            PlayIdle();
            m_MyVar = myVar;
        }

        if (Healthbar.value >= 0 && PlayerDead == false)
        {
            anim.Play("Player_Dead", -1, 0f);
            PlayerDead = true;
            DyingSource.clip = DyingSounds[0];
            DyingSource.Play();
        }
    }

    void PlayIdle()
    {
        anim.Play("Player_Idle", -1, 0f);
        Handle.Play("HandleBump", -1, 0f);
    }
}

