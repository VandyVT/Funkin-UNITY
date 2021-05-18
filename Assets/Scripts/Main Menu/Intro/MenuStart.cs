using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private bool IntroMode;
    [SerializeField] private bool IsLoading;
    [SerializeField] private bool AllowStart;
    [SerializeField] private AudioSource MenuMusic;
    [SerializeField] private AudioSource UIStartSound;
    [SerializeField] private Animator IntroCanvas;
    [SerializeField] private Animator GradientCanvas;
    [SerializeField] private Animator EnterButton;

    public KeyCode kCode;
    private bool AllowEnter;
    [SerializeField] private float normalizedTime;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void MusicBeginner()
    {
        if(IntroMode == true)
        {
            MenuMusic.Play();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(kCode) && IsLoading == true)
        {
            IntroCanvas.Play("StarterWait", 0, normalizedTime);
        }

        if (Input.GetKeyDown(kCode) && AllowStart == true && AllowEnter == false)
        {
            AllowEnter = true;
            UIStartSound.Play();
            EnterButton.Play("ButtonStart");
            Invoke("GradientPlayer", 1.8f);
            Invoke("MenuLoader", 2.5f);
        }
    }

    void GradientPlayer()
    {
        GradientCanvas.Play("GradientMove");
    }

    void MenuLoader()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
