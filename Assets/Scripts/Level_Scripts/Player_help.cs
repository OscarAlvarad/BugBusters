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
       // Debug.Log("Position on X: " + Player.transform.position.x);     

        if (player_in_position )
        {
            TutorialTextHandler();

        } else {frozen = false;}

        finished = Isfinished();
    }

    private bool Isfinished()
    {
        return finished;
    }

    public void PanelShow()
    {
        Tutorial_text.SetText("");
        Tutorial_text.gameObject.SetActive(true);
        text_started = false;
        PanelCounter = 0;
        TutorialTextHandler();
    }

    private bool IsPlayerInPosition(float PositionInX)
    {
        return PositionInX > -2.7 && PositionInX < 1.3;
    }

    public void TutorialTextHandler()
    {
        if (PanelCounter < 1) { Panel.SetActive(true); }
        PanelCounter++; 

        if (!text_started)
        {
            StartText();
            text_started = true;
        }

        if (finished) { help_ok_button.gameObject.SetActive(true); }
           else { help_ok_button.gameObject.SetActive(false); }
    }

    public void HelpOkButtonFunction()
    {
        if (text_started)
        {
            switch (OkButtonTracker)
            {
                case 0:
                    Tutorial_text.SetText("");
                    WriteNextLine();                    
                    break;    
                case 1:
                    Tutorial_text.SetText("");
                    WriteNextLine();
                    break;
                default:
                    break;
            }
        }

        OkButtonTracker++;
        Debug.Log(OkButtonTracker);

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
        Tutorial_text.SetText("");
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
       
        if (DialogueIndex < lengthofline-1)
        {
            DialogueIndex++;
            Tutorial_text.SetText("");
            StartCoroutine(Writeline());
        } else
        {
            Debug.Log("Lmao");
        }
        
    }

}
