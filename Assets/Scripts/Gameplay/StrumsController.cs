using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrumsController : MonoBehaviour
{
    [SerializeField] private Image[] PlayerArrows;
    [SerializeField] private Image[] EnemyArrows;

    [SerializeField] private Sprite[] staticImages;
    [SerializeField] private Sprite[] pressImages;
    [SerializeField] private Sprite[] confirmImages;
    public bool[] enemyConfirmArray = { false, false, false, false };
    public bool[] playerConfirmArray = { false, false, false, false };
    public bool[] playerPressArray = { false, false, false, false };
    private static string[] dataArray = { "LEFT", "DOWN", "UP", "RIGHT"};

    public static float upScrollY = 160f;
    public static float upScrollYConfirm => upScrollY-3.6f;

    public static float downScrollY = -165f;
    public static float downScrollYConfirm => downScrollY - 3.6f;

    public static float swagWidth = 160f;

    void Update()
    {
        playerPressArray = InputManager.HoldArray;
        for (int i = 0; i < PlayerArrows.Length; i++)
        {
            Image strum = PlayerArrows[i];

            float y;
            float x = swagWidth * i;
            x += Screen.width / 2;
            x += 350;
            if (GameplayChangeables.downScroll)
            {
                if (playerConfirmArray[i])
                    y = downScrollYConfirm;
                else
                    y = downScrollY;
            }
            else
            {
                if (playerConfirmArray[i])
                    y = upScrollYConfirm;
                else
                    y = upScrollY;
            }

            //Why the FUCK is this needed????
            if (playerConfirmArray[i])
            {
                strum.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
            else
            {
                strum.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            //strum.transform.localPosition = new Vector3(strum.transform.localPosition.x, y, strum.transform.localPosition.z);
            //strum.transform.position = new Vector3(x, strum.transform.position.y, strum.transform.position.z);

            if (playerConfirmArray[i])
            {
                strum.sprite = confirmImages[i];
            }
            else
            {
                if (playerPressArray[i])
                {
                    strum.sprite = pressImages[i];
                }
                else
                {
                    strum.sprite = staticImages[i];
                }
            }
        }
        for (int i = 0; i < EnemyArrows.Length; i++)
        {
            Image strum = EnemyArrows[i];
            float y;
            float x = swagWidth * i;
            x += 150;
            if (GameplayChangeables.downScroll)
            {
                if (enemyConfirmArray[i])
                    y = downScrollYConfirm;
                else
                    y = downScrollY;
            }
            else
            {
                if (enemyConfirmArray[i])
                    y = upScrollYConfirm;
                else
                    y = upScrollY;
            }

            //Why the FUCK is this needed????
            if (enemyConfirmArray[i])
            {
                strum.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
            else
            {
                strum.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            //strum.transform.localPosition = new Vector3(strum.transform.localPosition.x, y, strum.transform.localPosition.z);
            //strum.transform.position = new Vector3(x, strum.transform.position.y, strum.transform.position.z);
            if (enemyConfirmArray[i])
            {
                strum.sprite = confirmImages[i];
            }
            else
            {
                strum.sprite = staticImages[i];
            }
        }
    }
}
