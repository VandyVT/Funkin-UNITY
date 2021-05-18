using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    [SerializeField] private bool StoryMode;
    [SerializeField] private bool Freeplay;

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
}
