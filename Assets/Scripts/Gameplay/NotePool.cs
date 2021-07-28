using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NotePool : MonoBehaviour
{
    public ArrowControl prefab;
    public List<ArrowControl> objects = new List<ArrowControl>();

    public ArrowControl Grab(NoteData data)
    {
        if(objects.Any(a=>!a.enabled))
        {
            Debug.Log("Spawn old");
            var obj = objects.First(a=>!a.gameObject.activeInHierarchy);
            obj.gameObject.SetActive(true);
            obj.Initialize(data);
            return obj;
        }
        else
        {
            Debug.Log("Spawn new");
            var obj = Instantiate(prefab, transform, false);
            obj.Initialize(data);
            obj.gameObject.SetActive(true);
            objects.Add(obj);
            return obj;
        }
    }
}
