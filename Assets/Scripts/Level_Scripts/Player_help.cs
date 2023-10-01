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

    public GameObject Player;

    public bool finished = false;
    public bool player_in_position = false;
    public bool frozen = false;
    public bool text_started = false;
    public bool button_pressed_flag = false;

    public string[] lines;
    public int lengthofline = 0;
    public float textspeed = 0.1f;


    void Start()
    {
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

        } else
        {
            frozen = false;
        }

    }

    private bool IsPlayerInPosition(float PositionInX)
    {
        return PositionInX < 1.7 && PositionInX > 1.3;
    }

    public void HelpOkButtonFunction()
    {
        Tutorial_text.gameObject.SetActive(false);
        help_ok_button.gameObject.SetActive(false);
    }

    public void StartText()
    {
       
        StartCoroutine(Writeline());
    }

    IEnumerator Writeline()
    {
        lengthofline = lines.Length;
        if (lengthofline != 0)
        {
            foreach (char item in lines[0].ToCharArray())
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
