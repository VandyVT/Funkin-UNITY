using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LastFocus : MonoBehaviour
{
    public int curSelected;
    public GameObject[] Objects;
    public bool[] lastInput = new bool[] { false, false, false, false };
    void Start()
    {
    }


    void Update()
    {
        //if (lastInput == InputManager.PressArray) return;
        //lastInput = InputManager.PressArray;
        //too lazy too actually do this right LOL
        if (InputManager.PressArray[(int)InputAction.Down])
        {
            curSelected++;
        }
        if (InputManager.PressArray[(int)InputAction.Up])
        {
            curSelected--;
        }
        if (curSelected > Objects.Length - 1)
            curSelected = 0;
        if (curSelected < 0)
            curSelected = Objects.Length-1;

        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[curSelected].GetComponent<Animator>().SetBool("Selected", i == curSelected);
        }
    }
}
