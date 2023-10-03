using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using System.Diagnostics.Tracing;

public class Player_help : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Tutorial_text;
    [SerializeField] public Button help_ok_button;
    [SerializeField] public GameObject Panel;

    public GameObject Player;

    public bool finished = false;
    public bool player_in_position = false;
    public bool frozen = false;
    public bool text_started = false;
    public bool button_pressed_flag = false;
    public bool WriteLineBreak = false;


    public int PanelCounter = 0;

    public string[] lines;
    public int lengthofline = 0;
    public float textspeed = 0.1f;

    int DialogueIndex = 0;
    int OkButtonTracker = 0;
    


    void Start()
    {
        Panel.SetActive(false);
        help_ok_button.gameObject.SetActive(false);
        Player = GameObject.Find("Carlos");
    }

  
    void Update()
    {
  
        float position_x = Player.transform.position.x;
        player_in_position = IsPlayerInPosition(position_x);
              
        if (player_in_position)
        {
            frozen = true;
            if (PanelCounter < 1) { Panel.SetActive(true); }
            PanelCounter++;
                       
            if (!text_started)
            {
                StartText();
                text_started = true;
            }
                       
            if (finished) {
               
                if (!button_pressed_flag) 
                {
                    help_ok_button.gameObject.SetActive(true);
                    button_pressed_flag = true; 
                }
                
                frozen = false;
            }

        } else {frozen = false;}

    }

    public void PanelShow()
    {
        Tutorial_text.SetText("");
        Panel.SetActive(true);
        Tutorial_text.gameObject.SetActive(true);
        help_ok_button.gameObject.SetActive(true);
        StartText();
    }

    private bool IsPlayerInPosition(float PositionInX)
    {
        return PositionInX < 1.7 && PositionInX > 1.3;
    }

    public void HelpOkButtonFunction()
    {

        if (text_started)
        {
            switch (OkButtonTracker)
            {
                case 0:
                    WriteNextLine();                    
                    break;    
                case 1:
                    WriteNextLine();
                    break;
                default:
                    break;
            }
        }

        OkButtonTracker++;

        if (OkButtonTracker >= 3)
        {
            Panel.SetActive(false);
            Tutorial_text.gameObject.SetActive(false);
            help_ok_button.gameObject.SetActive(false);
            OkButtonTracker = 0;
        }
        
    }

    public void StartText()
    {
        DialogueIndex= 0;
        StartCoroutine(Writeline());
    }

    IEnumerator Writeline()
    {
        finished = false;
        lengthofline = lines.Length;
        if (lengthofline != 0)
        {
            foreach (char item in lines[DialogueIndex].ToCharArray())
            {
                Tutorial_text.text += item;
                if (WriteLineBreak) { Tutorial_text.SetText(""); break; }
                yield return new WaitForSeconds(textspeed);
            }
        }
        else
        {
            Debug.Log("it went bananas");
        }


        finished = true;
    }

    public void WriteNextLine()
    {
        finished = false;
        if (DialogueIndex < lengthofline-1)
        {
            DialogueIndex++;
            Tutorial_text.SetText("");
            StartCoroutine(Writeline());
        } else
        {
            Debug.Log("Lmao");
        }
        finished = true;
    }

}
