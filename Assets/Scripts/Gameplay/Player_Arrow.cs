using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arrow : MonoBehaviour
{
    [SerializeField] private Animator PlayerArrows;

    void Update()
    {
        //Left Arrow Animation
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerArrows.Play("Left.Left_Press");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayerArrows.Play("Left.Left_None");
        }

        //Right Arrow Animation
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerArrows.Play("Down.Down_Press");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayerArrows.Play("Down.Down_None");
        }

        //Up Arrow Animation
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerArrows.Play("Up.Up_Press");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayerArrows.Play("Up.Up_None");
        }

        //Right Arrow Animation
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerArrows.Play("Right.Right_Press");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerArrows.Play("Right.Right_None");
        }
    }
}
