using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    private float checkPointPositionX, checkPointPositionY;

   

    //public Animator animator;
    private void Start()
    {
        //Para debugeo
        //PlayerPrefs.SetFloat("checkPointPositionX", 0);
        //PlayerPrefs.SetFloat("checkPointPositionY", 0);



        life = hearts.Length;

        if(PlayerPrefs.GetFloat("checkPointPositionX")!= 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void checkLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            //animator.Play("Hit");

            if (PlayerPrefs.HasKey("checkPointPositionX"))
            {
                PlayerPrefs.DeleteKey("checkPointPositionX");
                Debug.Log("Checkpoint position X deleted");
            }
            if (PlayerPrefs.HasKey("checkPointPositionY"))
            {
                PlayerPrefs.DeleteKey("checkPointPositionY");
                Debug.Log("Checkpoint position Y deleted");
            }
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            //animator.Play("Hit");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            //animator.Play("Hit");
        }
    }
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
 
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        life--;
        checkLife();
    }
}
