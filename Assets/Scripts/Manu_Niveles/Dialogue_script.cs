using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class Dialogue_script : MonoBehaviour
{
    [SerializeField] public GameObject Text_panel;
    [SerializeField] public TextMeshProUGUI Tutorial_text;
    public bool finished = false;

    public string[] lines;
    public int lengthofline = 0;
    public float textspeed = 0.1f;
    int index = 0;

    void Start()
    {
        Start_Text();
    }

    public void Start_Text()
    {
        index = 0;
        StartCoroutine(Writeline());
    }

    IEnumerator Writeline()
    {
        lengthofline = lines.Length;
        if (lengthofline != 0)
        {
            foreach (char item in lines[index].ToCharArray())
            {
                Tutorial_text.text += item;

                yield return new WaitForSeconds(textspeed);
            }
        } else
        {
            Debug.Log("it went bananas");
        }
        

        finished = true;
    }



}
