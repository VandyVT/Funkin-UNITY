using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField] public bool StoryMode;
    [SerializeField] public bool Freeplay;

    public GameObject IntroMusic;
    public GameObject MenuMusic;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        IntroMusic = GameObject.Find("IntroMusic");
        if(IntroMusic)
        {
            MenuMusic.GetComponent<AudioSource>().Stop();
        }

        else
        {
            MenuMusic.GetComponent<AudioSource>().Play();
        }
    }

    public void ToggleStory()
    {
        StoryMode = !StoryMode;
    }

    public void ToggleFreeplay()
    {
        Freeplay = !Freeplay;
    }
}
