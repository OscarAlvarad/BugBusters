using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Guardi_ayuda : MonoBehaviour
{
    [SerializeField] public GameObject target_panel;
    [SerializeField] public Button Guardi_ayuda_button_on;
    [SerializeField] public Button Guardi_ayuda_button_off;

    public bool panel_started = false;
    public bool panel_active = false;
    public int counter_1;

    void Start()
    {
       target_panel.SetActive(false);


    }

  
    void Update()
    {
        if (panel_started)
        {
            if (finished)
            {
                Guardi_ayuda_button_off.interactable=true;
            }
        }
    }


    public void panel_controls()
    {
        if (!target_panel.activeSelf)
        {
            target_panel.SetActive(true);
            Debug.Log("off");

        }
        if (target_panel.activeSelf)
        {
            target_panel.SetActive(false);
            Debug.Log("on");
        }

        
    }

    public void button_on()
    {
        counter_1++;
        if (!target_panel.activeSelf)
        {
            target_panel.SetActive(true);
            if (counter_1 >= 1)
            {
                Start_Text();            
            } 
            
            Guardi_ayuda_button_on.interactable = false;
            panel_started = true;
            
           
        } 
    }

    public void button_off()
    {
        target_panel.SetActive(false);
        Guardi_ayuda_button_on.interactable = true;
        
        Debug.Log("point");
    }




    [SerializeField] public GameObject Text_panel;
    [SerializeField] public TextMeshProUGUI Tutorial_text;
    public bool finished = false;

    public string[] lines;
    public int lengthofline = 0;
    public float textspeed = 0.1f;
    int index = 0;

    public void Start_Text()
    {
        index = 0;
        StartCoroutine(Writeline());
    }

    IEnumerator Writeline()
    {
        finished = false;
        lengthofline = lines.Length;
        if (lengthofline != 0)
        {
            foreach (char item in lines[index].ToCharArray())
            {
                Tutorial_text.text += item;

                yield return new WaitForSeconds(textspeed);
            }
        }
        else
        {
            Debug.Log("it went bananas");
        }


        finished = true;
    }

    
}
