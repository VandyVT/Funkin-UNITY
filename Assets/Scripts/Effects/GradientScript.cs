using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientScript : MonoBehaviour
{
    [SerializeField] private Animator GradientCanvas;
    public bool Player;
    public bool Stopper;
    void Start()
    {
        if (Player == true)
        {
            GradientPlayer();
        }

        if (Stopper == true)
        {
            GradientStopper();
        }
    }

    void GradientPlayer()
    {
        GradientCanvas.Play("GradientMove");
    }

    void GradientStopper()
    {
        GradientCanvas.Play("GradientOut");
    }
}
