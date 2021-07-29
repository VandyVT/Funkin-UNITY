using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControl : MonoBehaviour
{
    [Header("Arrow Type")]
    [Header("0 = Left | 1 = Down | 2 = Up | 3 = Right")]
    [Range(0, 3)]
    public int ArrowTypeSelect;

    [Header("Must Hit Note")]
    public bool MustHit;

    [Header("At Strum")]
    public bool AtStrum;

    [Header("Too Late")]
    public bool tooLate;

    [Header("Was Good Hit")]
    public bool wasGoodHit;

    [Header("Is Sustain Note")]
    public bool isSustainNote;

    [Header("Note Length")]
    [Range(0, 9999)]
    public float sustainLength;

    [Header("Scroll Speed")]
    public float scrollSpeed;

    [Header("Strum Time")]
    public float strumTime;

    public Sprite[] ArrowTypeSprites;

    GameObject ConductOBJ;
    GameObject Strum;
    public void Initialize(NoteData data)
    {
        ArrowTypeSelect = data.type % 3;
        sustainLength = data.length;
        strumTime = data.strumTime;
        MustHit = data.section.mustHitSection;
    }
    void Start()
    {
        if (MustHit)
        {
            Strum = StrumHolder.instance.playerStrums.objs[ArrowTypeSelect];
        }
        else
        {
            Strum = StrumHolder.instance.enemyStrums.objs[ArrowTypeSelect];
        }
        transform.SetParent(Strum.transform, false);
        GetComponent<Image>().sprite = ArrowTypeSprites[ArrowTypeSelect];
        ConductOBJ = GameObject.Find("Conductor");
    }
    
    void Update()
    {
        transform.localPosition = new Vector3(0, 0.45f + (ConductOBJ.GetComponent<MusicConduct>().songPosition - strumTime) * scrollSpeed/2f, 0f);
        if(MustHit)
        {
            if (isSustainNote)
            {
                if (strumTime > MusicConduct.Instance.songPosition - (MusicConduct.Instance.safeZoneOffset * 1.5)
                    && strumTime < MusicConduct.Instance.songPosition + (MusicConduct.Instance.safeZoneOffset * 0.5))
                    AtStrum = true;
                else
                    AtStrum = false;
            }
            else
            {
                if (strumTime > MusicConduct.Instance.songPosition - MusicConduct.Instance.safeZoneOffset
                    && strumTime < MusicConduct.Instance.songPosition + MusicConduct.Instance.safeZoneOffset)
                    AtStrum = true;
                else
                    AtStrum = false;
            }

            if (strumTime < MusicConduct.Instance.songPosition - MusicConduct.Instance.safeZoneOffset * MusicConduct.Instance.timeScale && !wasGoodHit)
                tooLate = true;
        }
        else
        {
            if (strumTime <= MusicConduct.Instance.songPosition)
                AtStrum = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ArrowDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
