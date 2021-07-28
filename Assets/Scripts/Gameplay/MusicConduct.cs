using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class MusicConduct : MonoBehaviour
{
    public static MusicConduct Instance;
    [Header("Technical Info")]
    public float songBpm;
    public bool started;
    private bool startedMusic;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float safeZoneOffset;
    public float safeFrames = 10;
    public float timeScale;
    float dspSongTime;
    [SerializeField] private float firstBeatOffset;
    public int BobInt;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource voiceSource;
    public GameObject Note;
    public Slider Healthbar;
    public Image BF_Canvas; 
    public Animator BF_Anim;
    public Sprite[] Boyfriend;
    public GameObject[] DisableOnDeath;
    public AudioSource insts;
    public AudioSource vocals;
    
    public float m_GFVar = 0;
    public float GFBobRate;

    [Header("Song Info")]
    public string songName = "Bopeebo";
    public string songDiff = "-hard";
    public float bpm;
    public int nextIndex = 0;
    public SongData map;
    public List<NoteData> notes;

    [Header("Characters")]
    public Animator Player;
    public Animator Girlfriend;


    private void Awake() {
        if(Instance != null) return;
        Instance = this;
    }
    void Start()
    {
        if (File.Exists(Path.Combine(Application.dataPath, "Maps", songName.ToLower(), songName.ToLower() + songDiff + ".json")))
        {
            map = SongData.LoadSong(Path.Combine(Application.dataPath, "Maps", songName.ToLower(), songName.ToLower() + songDiff + ".json")).song;
        }
        else
        {
            map = JsonConvert.DeserializeObject<SongData.Root>(PresetMapGrabber.GetMap(songName, songDiff)).song;
        }
        notes = map.Notes.SelectMany((SectionData a) => a.notes).ToList();
        notes.Sort((x, y) => x.strumTime.CompareTo(y.strumTime));
        Spawner.instance.SpawnAllNotes(notes);
        //Number of seconds in each beat
        safeZoneOffset = Mathf.Floor(safeFrames / 60 * 1000);
        timeScale = safeZoneOffset / 166;
        secPerBeat = 60f / songBpm;
        bpm = songBpm;
        m_GFVar = BobInt;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
    }
    
    void Update()
    {
        if (!started) return;
        if(started && !startedMusic)
        {
            insts.Play();
            vocals.Play();
            startedMusic = true;
            dspSongTime = (float)AudioSettings.dspTime;
        }
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
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset) * 1000f;

        //Sync voices & music
        if (musicSource.isPlaying && voiceSource.isPlaying)
        {
            voiceSource.timeSamples = musicSource.timeSamples;
        }

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        BobInt = (int)songPositionInBeats;

        if (m_GFVar < BobInt && Girlfriend.GetCurrentAnimatorStateInfo(0).IsName("GF_Dance")) 
        {
            Girlfriend.speed = GFBobRate;
            m_GFVar = BobInt;
        } 
    }
}
