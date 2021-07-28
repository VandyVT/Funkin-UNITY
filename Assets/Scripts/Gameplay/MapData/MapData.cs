using Newtonsoft.Json;
using System;
using System.IO;

[Serializable]
public class SongData
{
    public class Root
    {
        public SongData song;
    }

    public SongData(string player2, string player1, long speed, bool voices, string songName, long bpm)
    {
        Player1 = player1;
        Player2 = player2;
        Speed = speed;
        NeedsVoices = voices;
        SongSong = songName;
        Bpm = bpm;
    }

    public string Player2;

    public string Player1;

    public long Speed;

    public bool NeedsVoices;

    public object[] SectionLengths;

    public string SongSong;

    public SectionData[] Notes;

    public long Bpm;

    public static Root LoadSong(string filePath)
    {
        return JsonConvert.DeserializeObject<Root>(File.ReadAllText(filePath));
    }

}
