using UnityEngine;
using UnityEngine.UI;

//Lazy
public class LazyAnimTransfer : MonoBehaviour
{
    void Update()
    {
        GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
