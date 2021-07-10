using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowControl : MonoBehaviour
{
    [HeaderAttribute("Arrow Type")]
    [Header("0 = Left | 1 = Down | 2 = Up | 3 = Right")]
    [Range(0, 3)]
    public int ArrowTypeSelect;

    [HeaderAttribute("Arrow Length")]
    [Range(0, 9999)]
    public int SliderLength;

    [HeaderAttribute("Arrow Speed")]
    public int ArrowSpeed;

    public Sprite[] ArrowTypeSprites;
    float beatTempo;
    GameObject ConductOBJ;

    void Start()
    {
        switch (ArrowTypeSelect)
        {
            case 0: GetComponent<Image>().sprite = ArrowTypeSprites[0];
                break;
            case 1:
                GetComponent<Image>().sprite = ArrowTypeSprites[1];
                break;
            case 2:
                GetComponent<Image>().sprite = ArrowTypeSprites[2];
                break;
            case 3:
                GetComponent<Image>().sprite = ArrowTypeSprites[3];
                break;
            default:
                print("Incorrect Arrow Type Selection");
                break;
        }
        ConductOBJ = GameObject.Find("Conductor");
        beatTempo = ConductOBJ.GetComponent<MusicConduct>().songBpm;
        beatTempo = beatTempo / 0.37f;
    }
    
    void Update()
    {
        transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
