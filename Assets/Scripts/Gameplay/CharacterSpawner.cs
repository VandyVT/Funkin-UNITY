using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public RuntimeAnimatorController[] characterPrefabs;
    public List<string> characterNames;
    public Character bf;
    public Character gf;
    public Character dad;

    public void Start()
    {
        bf.GetComponent<Animator>().runtimeAnimatorController = characterPrefabs[characterNames.IndexOf(bf.character)];
        gf.GetComponent<Animator>().runtimeAnimatorController = characterPrefabs[characterNames.IndexOf(gf.character)];
        dad.GetComponent<Animator>().runtimeAnimatorController = characterPrefabs[characterNames.IndexOf(dad.character)];
    }
}
