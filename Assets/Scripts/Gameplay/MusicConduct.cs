using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicConduct : MonoBehaviour
{
    public static MusicConduct Instance;
    [Header("Technical Info")]
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    float dspSongTime;
    [SerializeField] private float firstBeatOffset;
    public int BobInt;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource voiceSource;
    public GameObject Note;
    public Slider Healthbar;
    public Image BF_Canvas;
    public Sprite[] Boyfriend;
    public GameObject[] DisableOnDeath;
    
    public float m_GFVar = 0;
    public float GFBobRate;

    [Header("Song Info")]
    public float bpm;
    public float[] notes;
    public int nextIndex = 0;

    [Header("Characters")]
    public Animator Player;
    public Animator Girlfriend;

    private void Awake() {
        if(Instance != null) return;
        Instance = this;
    }
    void Start()
    {
        //Number of seconds in each beat
        secPerBeat = 60f / songBpm;
        bpm = songBpm;
        m_GFVar = BobInt;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Healthbar.value = 0;
        }
            //Change UI character images based on health value
        if (Healthbar.value > -21)
        {
            BF_Canvas.GetComponent<Image>().sprite = Boyfriend [1];
        }

        else
        {
            BF_Canvas.GetComponent<Image>().sprite = Boyfriend[0];
        }

        //Initiate death sequence when slider value is 0
        if(Healthbar.value >= 0)
        {
            musicSource.Stop();
            voiceSource.Stop();
            for (int i = 0; i < DisableOnDeath.Length; i++)
            {
                DisableOnDeath[i].SetActive(false);
                Destroy(DisableOnDeath[i].gameObject);
            }
            Destroy(gameObject);
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
        BobInt = (int)songPositionInBeats;
        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats)
        {
            Instantiate(Note);
            //initialize the fields of the music note
            nextIndex++;
        }

        if (m_GFVar < BobInt && Girlfriend.GetCurrentAnimatorStateInfo(0).IsName("GF_Dance")) 
        {
            Girlfriend.speed = GFBobRate;
            m_GFVar = BobInt;
        } 
    }
}
