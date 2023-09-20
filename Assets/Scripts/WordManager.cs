using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public void AllWordCollected()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("No quedan palabras, victoria");
        }
    }
}
