using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using Unity.VisualScripting;
using TMPro;


public class Menu_Opciones : MonoBehaviour
{

    /* 
      Este Script maneja las opciones del menu y que los botones del menu hagan sonido asi como el nivel de calidad en la imagen
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
            calidad.value = PlayerPrefs.GetInt("Quality", 0);
        }
        else
        {
            calidad.value =0;
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

    public void CambiarCalidad_2()
    {
        int calidad_value = calidad.value;
        QualitySettings.SetQualityLevel(calidad_value);
        int to_PlayerPrefs = QualitySettings.GetQualityLevel();
        PlayerPrefs.SetInt("Quality", to_PlayerPrefs);

        // Calidad es el dropdown, con int calidad_value = calidad.value se guarda el valor del dropdown
        // calidad_value se guarda en QualitySettings, se llama ese valor a to_playerprefs y este lo guara en PlayerPrefs bako "Quality"

    }




}
