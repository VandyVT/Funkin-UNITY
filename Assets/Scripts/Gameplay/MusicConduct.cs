using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicConduct : MonoBehaviour
{
    [Header("Technical Info")]
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    float dspSongTime;
    [SerializeField] private float firstBeatOffset;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource voiceSource;
    public GameObject Note;
    public Slider Healthbar;
    public Image BF_Canvas;
    public Sprite[] Boyfriend;

    [Header("Song Info")]
    public float bpm;
    public float[] notes;
    public int nextIndex = 0;

    //The animator controller to the player
    public Animator Player;

    void Start()
    {
        //Number of seconds in each beat
        secPerBeat = 60f / songBpm;
        bpm = songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
    }
    
    void Update()
    {
        //Change UI character images based on health value
        if(Healthbar.value > -25)
        {
            BF_Canvas.GetComponent<Image>().sprite = Boyfriend [1];
        }

        else
        {
            BF_Canvas.GetComponent<Image>().sprite = Boyfriend[0];
        }

        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //Sync voices & music
        if (musicSource.isPlaying && voiceSource.isPlaying)
        {
            voiceSource.timeSamples = musicSource.timeSamples;
        }

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats)
        {
            Instantiate(Note);
            //initialize the fields of the music note
            nextIndex++;
        }
    }
}
