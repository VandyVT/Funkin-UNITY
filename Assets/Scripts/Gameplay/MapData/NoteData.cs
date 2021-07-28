using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NoteData
{
    public float strumTime;
    public float length;
    public int type;
    [NonSerialized]
    [HideInInspector]
    public SectionData section;

    public static implicit operator NoteData(List<decimal> d)
    {
        var a = new NoteData();
        a.strumTime = (float)d[0];
        a.type = (int)d[1];
        a.length = (float)d[2];
        return a;
    }

    public static implicit operator List<decimal>(NoteData n)
    {
        var a = new List<decimal>();
        a.Add((decimal)n.strumTime);
        a.Add(n.type);
        a.Add((decimal)n.length);
        return a;
    }
}
