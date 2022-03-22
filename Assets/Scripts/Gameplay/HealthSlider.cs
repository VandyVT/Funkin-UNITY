using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public GameObject[] WhatToDestroy;
    public Animator Bf;
    public Slider thisSlider;
    public AudioSource BfDeath;
    
    void Update()
    {
        if (thisSlider.value == 0)
        {
            foreach (GameObject i in WhatToDestroy)
            {
                Destroy(i);
            }
            Bf.Play("BF dies", 0, 0);
            BfDeath.Play();
        }
    }
}
