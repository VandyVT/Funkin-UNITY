using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetMapGrabber : MonoBehaviour
{
    public static string GetMap(string name, string diff)
    {
        return Resources.Load<TextAsset>("preload/data/" + name.ToLower() + "/" + name.ToLower() + diff + ".json").text;
    }
}
