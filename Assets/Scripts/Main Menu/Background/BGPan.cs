using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGPan : MonoBehaviour
{
    public Vector3 pz;
    public Vector3 StartPos;

    public int moveModifier;
    
    void Start()
    {
        StartPos = transform.position;
    }
    
    void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;

        transform.position = new Vector3(StartPos.x + (pz.x * moveModifier), StartPos.y + (pz.y * moveModifier), 0);
        //move based on the starting position and its modified value.
    }
}

