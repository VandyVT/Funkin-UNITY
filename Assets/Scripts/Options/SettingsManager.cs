using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public string SettingsToGet;

    public bool HideGF;
    public bool HideBF;
    public bool HideEnemy;
    public bool HideEnemyArrows;
    public bool HideStage;

    GameObject Toggle;
    SettingsMenu settings_menu;
    public Renderer GF;
    public Renderer BF;
    public Renderer Enemy;
    public GameObject EnemyArrows;
    public GameObject EnemyArrowOffscreen;
    public GameObject EnemyArrowOriginal;
    public GameObject Stage;

    void Awake()
    {
        Toggle = GameObject.Find(SettingsToGet);
        if (Toggle != null)
        {
            settings_menu = Toggle.GetComponent<SettingsMenu>();
        }
    }

    void Update()
    {
        if (Toggle != null)
        {
            if (HideGF == true)
            {
                GF.enabled = !settings_menu.HideGF;
            }

            if (HideBF == true)
            {
                BF.enabled = !settings_menu.HideBF;
            }

            if (HideEnemy == true)
            {
                Enemy.enabled = !settings_menu.HideEnemy;
            }

            if (settings_menu.HideEnemyArrows == true)
            {
                HideArrows();
            }
            else
            {
                ShowArrows();
            }


            if (HideStage == true)
            {
                Renderer[] renderStage = Stage.GetComponentsInChildren<Renderer>();

                int i = 0;
                for (i = 0; i < renderStage.Length; i++)
                {
                    foreach(var sr in renderStage)
                    {
                        renderStage[i].GetComponent<Renderer>().enabled = !settings_menu.HideStage;
                    }
                }
            }
        }
    }

    void HideArrows()
    {
        EnemyArrows.transform.position = EnemyArrowOffscreen.transform.position;
    }

    void ShowArrows()
    {
        EnemyArrows.transform.position = EnemyArrowOriginal.transform.position;
    }
}
