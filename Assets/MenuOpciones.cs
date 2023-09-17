using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class MenuOpciones : MonoBehaviour

{


    [SerializeField] private AudioMixer audioMixer;

    public Slider volumeSlider;

    void start()
    {

    }
    
    public void CambiarVolumen(float volumen)
    {
  
        audioMixer.SetFloat("Volumen", volumen); 


    }

    public void CambiarVolumenEfectos(float volumenfx)
    {
        audioMixer.SetFloat("VolumenFX", volumenfx);
        
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }



}
