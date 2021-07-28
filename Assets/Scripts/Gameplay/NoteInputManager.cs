using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInputManager : MonoBehaviour
{
    public static List<ArrowControl> allNotes = new List<ArrowControl>();
    public bool[] playerHolds;
    private StrumsController strums;
    private void Start()
    {
        strums = gameObject.GetComponent<StrumsController>();
        playerHolds = new bool[]{ false, false, false, false };
    }
    void Update()
    {
        if (!MusicConduct.Instance.started) return;
        for (int i = 0; i < allNotes.Count; i++)
        {
            ArrowControl control = allNotes[i];
            if(control.AtStrum)
            {
                if (!control.MustHit)
                {
                    control.AtStrum = false;
                    control.gameObject.SetActive(false);
                }
                else
                {
                    if(InputManager.PressArray[control.ArrowTypeSelect])
                    {
                        playerHolds[control.ArrowTypeSelect] = true;
                        control.AtStrum = false;
                        control.gameObject.SetActive(false);
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
    }
}
