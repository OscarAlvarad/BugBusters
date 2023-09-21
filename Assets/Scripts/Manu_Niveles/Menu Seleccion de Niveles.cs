using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelecciondeNiveles : MonoBehaviour
{
    [SerializeField] private bool desbloqueo;

    public Image ImagenDesbloqueo;
    public GameObject[] Estrellas;

    private void Update()
    {
        ActualizarImagenNivel();
    }
    private void ActualizarImagenNivel()
    {
        if (!desbloqueo)  //significa que si desbloqueo es falso el nivel esta bloqueado
        {
            ImagenDesbloqueo.gameObject.SetActive(true);
            for (int i = 0; i < Estrellas.Length; i++)
            {
                Estrellas[i].gameObject.SetActive(false);
            }
        }
        else
        {
            ImagenDesbloqueo.gameObject.SetActive(false);
            for (int i = 0; i < Estrellas.Length; i++)
            {
                Estrellas[i].gameObject.SetActive(true);
            }
        }
    }

    public void PressSelection(string _NombreNivel)
    {
        if (desbloqueo)
        {
            SceneManager.LoadScene(_NombreNivel);
        }
    }
}
