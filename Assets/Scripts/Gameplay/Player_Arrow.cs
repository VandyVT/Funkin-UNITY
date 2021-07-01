using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arrow : MonoBehaviour
{
    [SerializeField] private Animator PlayerArrows;

    void Update()
    {
        //Left Arrow Animation
        bool[] press = InputManager.PressArray;
        bool[] release = InputManager.ReleaseArray;
        if (press[0])
        {
            PlayerArrows.Play("Left.Left_Press");
        }
        if (release[0])
        {
            PlayerArrows.Play("Left.Left_None");
        }

        //Right Arrow Animation
        if (press[1])
        {
            PlayerArrows.Play("Down.Down_Press");
        }
        if (release[1])
        {
            PlayerArrows.Play("Down.Down_None");
        }

        //Up Arrow Animation
        if (press[2])
        {
            PlayerArrows.Play("Up.Up_Press");
        }
        if (release[2])
        {
            PlayerArrows.Play("Up.Up_None");
        }

        //Right Arrow Animation
        if (press[3])
        {
            PlayerArrows.Play("Right.Right_Press");
        }
        if (release[3])
        {
            PlayerArrows.Play("Right.Right_None");
        }
    }
}
