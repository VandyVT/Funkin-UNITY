using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInputManager : MonoBehaviour
{
    public static List<ArrowControl> allNotes = new List<ArrowControl>();
    public bool[] playerHolds;
    public bool[] enemyHolds;
    private StrumsController strums;
    public Character dad;
    public Character bf;
    private void Start()
    {
        strums = gameObject.GetComponent<StrumsController>();
        playerHolds = new bool[]{ false, false, false, false };
        enemyHolds = new bool[]{ false, false, false, false };
    }
    void Update()
    {
        bool[] laneExitArray = new bool[] { false, false, false, false };
        if (!MusicConduct.Instance.started) return;
        for (int i = 0; i < allNotes.Count; i++)
        {
            ArrowControl control = allNotes[i];
            if(control.AtStrum)
            {
                if (!control.MustHit)
                {
                    enemyHolds[control.ArrowTypeSelect] = true;
                    control.AtStrum = false;
                    control.gameObject.SetActive(false);
                    StartCoroutine(SwitchOffEnemyStrums(control.ArrowTypeSelect));
                }
                else
                {
                    if(InputManager.PressArray[control.ArrowTypeSelect] && !laneExitArray[control.ArrowTypeSelect])
                    {
                        playerHolds[control.ArrowTypeSelect] = true;
                        control.AtStrum = false;
                        control.gameObject.SetActive(false);
                        laneExitArray[control.ArrowTypeSelect] = true;
                    }
                    if (!InputManager.HoldArray[control.ArrowTypeSelect])
                    {
                        playerHolds[control.ArrowTypeSelect] = false;
                    }
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (!InputManager.HoldArray[i])
            {
                playerHolds[i] = false;
            }
        }
        strums.playerConfirmArray = playerHolds;
        strums.enemyConfirmArray = enemyHolds;
    }
    public IEnumerator SwitchOffEnemyStrums(int lane)
    {
        yield return new WaitForSeconds(0.1f);
        enemyHolds[lane] = false;
        strums.enemyConfirmArray = enemyHolds;
    }
}
