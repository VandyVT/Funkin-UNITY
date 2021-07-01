using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnim : MonoBehaviour
{
    public float songBpm;
     float secPerBeat;
     float songPosition;
     float songPositionInBeats;
     float dspSongTime;
    public AudioSource musicSource;
     float firstBeatOffset;

    public int myVar = 0; //Gets the int value for BobInt, which assigns it's value on the songPositionInBeats float
    public int BobInt;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
    }

    void Update()
    {
        BobInt = (int)songPositionInBeats;
        myVar = BobInt;
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPositionInBeats = songPosition / secPerBeat;
    }
}
