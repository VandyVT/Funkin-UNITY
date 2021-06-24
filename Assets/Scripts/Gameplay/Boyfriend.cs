using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyfriend : MonoBehaviour
{
    public MusicConduct mc;
    float characterBobRate;
    Animator anim;
    float tempTime;
    private void Start() {
        anim = GetComponent<Animator>();
    }
    private void OnEnable() {
        characterBobRate = 60f / mc.songBpm;
    }
    private void OnDisable() {
        
    }
    private void Update() {
        if(tempTime >= characterBobRate) {
            anim.speed = characterBobRate;
            tempTime = 0;
        } else tempTime += Time.deltaTime;
    }
}
