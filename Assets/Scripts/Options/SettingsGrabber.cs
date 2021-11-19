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
    public GameObject GF;

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
                GF.GetComponent<Renderer>().enabled = !Toggle.GetComponent<SettingsMenu>().HideGF;
            }
        }
    }

    public class Example
    {
        Dictionary<string, bool> _boolsDict = new Dictionary<string, bool>();

        //Some logic to populate the dictionary values...

        public bool GetValue(string key)
        {
            bool value = false;

            if (_boolsDict.ContainsKey(key))
            {
                value = _boolsDict[key];
            }

            return value;
        }
    }

    static object GetPropValue(object SettingsToGet, string BoolToGet)
    {
        return SettingsToGet.GetType().GetProperty(BoolToGet).GetValue(SettingsToGet);
    }
}
