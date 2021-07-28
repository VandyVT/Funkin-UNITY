using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boyfriend : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Animator Handle;
    public Slider Healthbar;
    private bool PlayerDead = false;
    public AudioSource DyingSource;
    public AudioClip[] DyingSounds;

    private void Update() {
        //if (MusicConduct.Instance.songPositionInBeats / 1000 % 4 == 0)
        //{
        //    PlayIdle();
        //}

        if (Healthbar.value >= 0 && PlayerDead == false)
        {
            anim.Play("Player_Dead");
            PlayerDead = true;
            DyingSource.clip = DyingSounds[0];
            DyingSource.Play();
        }
    }

    void PlayIdle()
    {
        anim.Play("BF idle dance", -1, 0f);
        Handle.Play("HandleBump", -1, 0f);
    }
}

