using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesGame : MonoBehaviour
{
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void Options()
    {
        //Panel Opciones
    }

    public void MenuNiveles()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel 1");
    }

}
