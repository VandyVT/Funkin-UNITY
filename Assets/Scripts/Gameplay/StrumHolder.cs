using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Strums
{
    public GameObject[] objs;
}

public class StrumHolder : MonoBehaviour
{
    public static StrumHolder instance;
    public Strums playerStrums;
    public Strums enemyStrums;
    private void Start()
    {
        instance = this;
    }
}
