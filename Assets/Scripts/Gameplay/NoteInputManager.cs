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
    Animator bfAnim;
    Animator dadAnim;

    private void Start()
    {
        strums = gameObject.GetComponent<StrumsController>();
        playerHolds = new bool[]{ false, false, false, false };
        enemyHolds = new bool[]{ false, false, false, false };
        bfAnim = bf.GetComponent<Animator>();
        dadAnim = dad.GetComponent<Animator>();
    }
    void Update()
    {
        if (bfAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            bfAnim.Play("BF idle dance");
        }
        if (dadAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            dadAnim.Play("Dad idle dance");
        }
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
                    if (control.ArrowTypeSelect == 0)
                    {
                        dadAnim.Play("Dad Sing Note LEFT", 0);
                    }
                    if (control.ArrowTypeSelect == 1)
                    {
                        dadAnim.Play("Dad Sing Note DOWN", 0);
                    }
                    if (control.ArrowTypeSelect == 2)
                    {
                        dadAnim.Play("Dad Sing Note UP", 0);
                    }
                    if (control.ArrowTypeSelect == 3)
                    {
                        dadAnim.Play("Dad Sing Note RIGHT", 0);
                    }
                }
                else
                {
                    if(InputManager.PressArray[control.ArrowTypeSelect] && !laneExitArray[control.ArrowTypeSelect])
                    {
                        playerHolds[control.ArrowTypeSelect] = true;
                        control.AtStrum = false;
                        control.gameObject.SetActive(false);
                        laneExitArray[control.ArrowTypeSelect] = true;

                        
                        if (control.ArrowTypeSelect == 0)
                        {
                            bfAnim.Play("BF NOTE LEFT", 0);
                        }
                        if (control.ArrowTypeSelect == 1)
                        {
                            bfAnim.Play("BF NOTE DOWN", 0);
                        }
                        if (control.ArrowTypeSelect == 2)
                        {
                            bfAnim.Play("BF NOTE UP", 0);
                        }
                        if (control.ArrowTypeSelect == 3)
                        {
                            bfAnim.Play("BF NOTE RIGHT", 0);
                        }
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
