using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrumsController : MonoBehaviour
{
    [SerializeField] private Animator[] PlayerArrows;
    [SerializeField] private Animator[] EnemyArrows;
    public bool[] enemyConfirmArray = { false, false, false, false };
    public bool[] playerConfirmArray = { false, false, false, false };
    public bool[] playerPressArray = { false, false, false, false };
    private static string[] dataArray = { "LEFT", "DOWN", "UP", "RIGHT"};

    private void Awake()
    {
        for (int i = 0; i < PlayerArrows.Length; i++)
        {
            Animator strum = PlayerArrows[i];
            strum.SetInteger("type", i);
        }
    }
    void Update()
    {
        playerPressArray = InputManager.HoldArray;
        for (int i = 0; i < PlayerArrows.Length; i++)
        {
            Animator strum = PlayerArrows[i];
            int value;
            if (playerConfirmArray[i])
            {
                value = 2;
            }
            else
            {
                if (playerPressArray[i])
                {
                    value = 1;
                }
                else
                {
                    value = 0;
                }
            }
            //strum.SetInteger("value", value);
        }
        for (int i = 0; i < EnemyArrows.Length; i++)
        {
            Animator strum = PlayerArrows[i];
            strum.SetInteger("type", i);
            int value = 0;
            if (enemyConfirmArray[i])
            {
                value = 2;
            }
            else
            {
                value = 0;
            }
            //strum.SetInteger("value", value);
        }
    }
}
