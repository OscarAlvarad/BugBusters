using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;
using TMPro;

public class Menu_Opciones : MonoBehaviour
{

    /* 
      Este Script maneja las opciones del menu y que los botones del menu hagan sonido
     */

    [SerializeField] private AudioMixer Audiomixer_1;
    [SerializeField] private Slider Volume_Slider;
    [SerializeField] private Slider FX_Slider;
    [SerializeField] public AudioSource Button_audio;
    [SerializeField] public TMP_Dropdown calidad;

    public void PlaySound()
    {
        Button_audio.Play();
    }


    public void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            Load_Music_Volume();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("FXVolume"))
        {
            Load_FX_Volume();
        }
        else
        {
            SetFXVolume();
        }

        if (PlayerPrefs.HasKey("Quality"))
        {
            GetCalidad(PlayerPrefs.GetInt("Quality"));
        } else
        {

        }

    }

    public void SetMusicVolume()
    {
        float volume = Volume_Slider.value;
        Audiomixer_1.SetFloat("music", MathF.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void Load_Music_Volume()
    {
        Volume_Slider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }

    public void SetFXVolume()
    {
        float volume = FX_Slider.value;
        Audiomixer_1.SetFloat("FX", MathF.Log10(volume) * 20);
        PlayerPrefs.SetFloat("FXVolume", volume);
    }

    private void Load_FX_Volume()
    {
        FX_Slider.value = PlayerPrefs.GetFloat("FXVolume");
        SetMusicVolume();
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
        int index_number = QualitySettings.GetQualityLevel();
        PlayerPrefs.SetInt("Quality",index_number);

    }

    public void GetCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }



}
