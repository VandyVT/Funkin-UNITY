using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private NotePool pool;
    public static Spawner instance;
    private void Start()
    {
        instance = this;
        pool = GetComponent<NotePool>();
    }
    public void SpawnAllNotes(List<NoteData> datas)
    {
        for (int i = 0; i < datas.Count; i++)
        {
            ArrowControl arrowControl = pool.Grab(datas[i]);
            NoteInputManager.allNotes.Add(arrowControl);
        }
    }
}
