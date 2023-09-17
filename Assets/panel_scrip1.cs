using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class panel_scrip1 : MonoBehaviour
{


    [SerializeField]

    public GameObject target_panel;
    public static int counter;
    


    // Start is called before the first frame update
    void Start()
    {
        target_panel.gameObject.SetActive(true);
        if (counter > 1 )
        {
            target_panel.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void hide_panel()
    {
        counter++;
        target_panel.gameObject.SetActive(false);
    }


    

}
