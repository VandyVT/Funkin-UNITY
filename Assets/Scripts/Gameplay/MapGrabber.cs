using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrabber
{
    public static string GetMap(string name, string diff)
    {
        return Resources.Load<TextAsset>("Maps/" + name.ToLower() + "/" + name.ToLower() + diff).text;
    }

    public static bool IsDefaultMap(string name, string diff)
    {
        var ye = Resources.Load<TextAsset>("Maps/" + name.ToLower() + "/" + name.ToLower() + diff).text;
        return ye != null;
    }
}
