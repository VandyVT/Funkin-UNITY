using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class MusicConduct : MonoBehaviour
{
    private static MusicConduct _Instance;
    public static MusicConduct Instance 
    {   
        get  
        {
            if(_Instance == null)
            {
                Debug.Log("Why the FUCK is this null???");
                _Instance = Resources.FindObjectsOfTypeAll<MusicConduct>().FirstOrDefault();
            }
            return _Instance;
        }
        private set
        {
            _Instance = value;
        }
    }
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
    public AudioSource insts;
    public AudioSource vocals;
    
    public float BobRate;

    [Header("Song Info")]
    public string songName = "Bopeebo";
    public string songDiff = "-hard";
    public float bpm;
    public int nextIndex = 0;
    public SongData map;
    public List<NoteData> notes;

    [Header("Characters")]
    public Animator gf;
    public Animator bf;
    public Animator dad;


    void Start()
    {
        Instance = this;
        if (File.Exists(Path.Combine(Application.dataPath, "StreamingAssets", "Maps", songName.ToLower(), songName.ToLower() + songDiff + ".json")))
            if (File.Exists(Path.Combine(Application.dataPath, "StreamingAssets", "Maps", songName.ToLower(), songName.ToLower() + songDiff + ".json")))
            {
            map = SongData.LoadSong(Path.Combine(Application.dataPath, "StreamingAssets", "Maps", songName.ToLower(), songName.ToLower() + songDiff + ".json")).song;
                map = SongData.LoadSong(Path.Combine(Application.dataPath, "StreamingAssets", "Maps", songName.ToLower(), songName.ToLower() + songDiff + ".json")).song;
            }
        else
        {
            map = JsonConvert.DeserializeObject<SongData.Root>(MapGrabber.GetMap(songName, songDiff)).song;
        }
        songBpm = map.Bpm;
        insts.clip = Resources.Load("songs/" + songName.ToLower() + "/Inst") as AudioClip;
        vocals.clip = Resources.Load("songs/" + songName.ToLower() + "/Voices") as AudioClip;
        notes = map.Notes.SelectMany((SectionData a) => a.notes).ToList();
        notes.Sort((x, y) => x.strumTime.CompareTo(y.strumTime));
        Spawner.instance.SpawnAllNotes(notes);
        //Number of seconds in each beat
        safeZoneOffset = Mathf.Floor(safeFrames / 60 * 1000);
        timeScale = safeZoneOffset / 166;
        secPerBeat = 60f / songBpm;
        bpm = songBpm;

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

        if (Healthbar.value >= -25)
        {

        }

        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset) * 1000f;

        //Sync voices & music
        if (musicSource.isPlaying && voiceSource.isPlaying)
        {
            voiceSource.time = musicSource.time;
        }

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        BobInt = (int)songPositionInBeats;
        BobRate = secPerBeat;
        gf.speed = songBpm/(60*2);
        //dad.speed = BobRate * 4;
        //bf.speed = BobRate * 2;
    }
}
