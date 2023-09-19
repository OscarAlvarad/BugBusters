using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class FX_Sounds : MonoBehaviour
{
    [SerializeField] public AudioSource Button_audio;


    public void PlaySound()
    {
        Button_audio.Play();
    }


}
