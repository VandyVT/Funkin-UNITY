using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputAction : int
{
    Left = 0,
    Down = 1,
    Up = 2,
    Right = 3
}
public static class InputManager
{
    private static KeyCode Up = KeyCode.J;
    private static KeyCode Down = KeyCode.F;
    private static KeyCode Left = KeyCode.D;
    private static KeyCode Right = KeyCode.K;

    public static bool[] HoldArray
    {
        get{
            return new bool[] { Input.GetKey(Left), Input.GetKey(Down), Input.GetKey(Up), Input.GetKey(Right) };
        }
    }

    public static bool[] PressArray
    {
        get
        {
            return new bool[] { Input.GetKeyDown(Left), Input.GetKeyDown(Down), Input.GetKeyDown(Up), Input.GetKeyDown(Right) };
        }
    }

    public static bool[] ReleaseArray
    {
        get
        {
            return new bool[] { Input.GetKeyUp(Left), Input.GetKeyUp(Down), Input.GetKeyUp(Up), Input.GetKeyUp(Right) };
        }
    }
}
