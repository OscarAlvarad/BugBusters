using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class panel_scrip1 : MonoBehaviour
{

   // para hide_panel
    [SerializeField] public GameObject target_panel;
    public Dialogue_script dialogue_Script;
    public Button button;
   
    


    public static int counter;
    public bool text_finished = false;
    

    void Start()
    {
        PlayerPrefs.DeleteAll();
        text_finished = dialogue_Script.finished;

        button.interactable = false;

            target_panel.gameObject.SetActive(true);
            if (counter >= 1)
            {
                target_panel.gameObject.SetActive(false);
            }
    }

    private void Update()
    {
        text_finished = dialogue_Script.finished;
        if (text_finished)
        {
            button.interactable = true; 
        }
        else
        {
            button.interactable = false;
        }
    }

    public void hide_panel_first_time()
    {
        counter++;
        target_panel.gameObject.SetActive(false);
    }

    public void hide_panel()
    {
        target_panel.gameObject.SetActive(false);
    }

    





}
