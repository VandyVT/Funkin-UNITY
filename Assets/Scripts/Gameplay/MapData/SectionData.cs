using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class SectionData
{
    public bool mustHitSection;

    public long typeOfSection;

    public long lengthInSteps;
    [HideInInspector]
    public List<List<decimal>> sectionNotes;
    [SerializeField]
    public List<NoteData> notes;

    public long? bpm;

    public bool? changeBPM;

    [OnDeserialized]
    public void SetNotes(StreamingContext context)
    {
        notes = sectionNotes.Select((List<decimal> d) => { return (NoteData)d; }).ToList();
        for (int i = 0; i < notes.Count; i++)
        {
            notes[i].section = this;
        }
    }
}