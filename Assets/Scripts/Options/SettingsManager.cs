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
    public GameObject GF;
    public GameObject BF;
    public GameObject Enemy;
    public GameObject EnemyArrows;
    public GameObject EnemyArrowOffscreen;
    public GameObject Stage;

    void Start()
    {
        Toggle = GameObject.Find(SettingsToGet);
        if (Toggle != null)
        {
            Toggle.GetComponent<SettingsMenu>();
        }
    }

    void Update()
    {
        if (Toggle != null)
        {
            if (HideGF == true)
            {
                GF.GetComponent<Renderer>().enabled = !Toggle.GetComponent<SettingsMenu>().HideGF;
            }

            if (HideBF == true)
            {
                BF.GetComponent<Renderer>().enabled = !Toggle.GetComponent<SettingsMenu>().HideBF;
            }

            if (HideEnemy == true)
            {
                Enemy.GetComponent<Renderer>().enabled = !Toggle.GetComponent<SettingsMenu>().HideEnemy;
            }

            if (HideEnemyArrows == true)
            {
                    Image[] renderArrows = EnemyArrows.GetComponentsInChildren<Image>();
                    //EnemyArrows.transform.position = EnemyArrowOffscreen.transform.position;

                    int i = 0;
                    for (i = 0; i < renderArrows.Length; ++i)
                    {
                        foreach (var sr in renderArrows)
                        {
                            renderArrows[i].GetComponent<Image>().enabled = !Toggle.GetComponent<SettingsMenu>().HideEnemyArrows;
                        }
                    }
                    //Toggle.GetComponent<SettingsMenu>().ArrowsMoved = false;
            }

            if (HideStage == true)
            {
                Renderer[] renderStage = Stage.GetComponentsInChildren<Renderer>();

                int i = 0;
                for (i = 0; i < renderStage.Length; i++)
                {
                    foreach(var sr in renderStage)
                    {
                        renderStage[i].GetComponent<Renderer>().enabled = !Toggle.GetComponent<SettingsMenu>().HideStage;
                    }
                }
            }
        }
    }
}
