using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGrabber : MonoBehaviour
{
    public string SettingsToGet;
    public string BoolToGet;

    public bool Hide;
    GameObject Toggle;

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
            if (Hide == true)
            {
                GetComponent<Renderer>().enabled = !Toggle.GetComponent<SettingsMenu>().HideGF;
            }
        }
    }

    static object GetPropValue(object SettingsToGet, string BoolToGet)
    {
        return SettingsToGet.GetType().GetProperty(BoolToGet).GetValue(SettingsToGet);
    }
}
