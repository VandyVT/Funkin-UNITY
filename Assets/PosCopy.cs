using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCopy : MonoBehaviour
{
    public GameObject copy;
    void Update()
    {
        if (copy != null)
        {
            transform.position = copy.transform.position;
            transform.rotation = copy.transform.rotation;
        }
    }
}
