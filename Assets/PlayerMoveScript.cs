using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;
    bool isJump = false;
    bool canJump = true;
    
    public bool frozen = false;
    // frozen es una condicion en Player_help que congela al jugador si esta en cierta posicion con el objetivo de
    // que se pueda leer el texto de ayuda de Barranquito, cuando este termina la condicion se anula y el jugador 
    // puede moverse normal

    public Rigidbody2D rb;
    public float speedForce;
    public float jumpForce;
    public float waitJump;
    public Animator anim;
    public SpriteRenderer spr;

    public Player_help Player_Help;
        
    public void clickLeft()
    {
        isLeft = true;
        anim.SetTrigger("Run");
        spr.flipX = false;
    }

    public void releaseLeft()
    {
        isLeft = false;
        anim.SetTrigger("Idle");
    }

    public void clickRight()
    {
        isRight = true;
        anim.SetTrigger("Run");
        spr.flipX = true;
    }
    public void releaseRight()
    {
        isRight = false;
        anim.SetTrigger("Idle");
    }

    public void clickJump()
    {
        isJump = true;
    }
    private void FixedUpdate()
    {
      frozen = Player_Help.frozen;
      
        if (!frozen)
        {
            Debug.Log("Not frozen");
            if (isLeft)
            {
                rb.AddForce(new Vector2(-speedForce, 0) * Time.deltaTime);
            }

            if (isRight)
            {
                rb.AddForce(new Vector2(speedForce, 0) * Time.deltaTime);
            }

            if (isJump && canJump)
            {
                isJump = false;
                rb.AddForce(new Vector2(0, jumpForce));
                canJump = false;
                Invoke("waitToJump", waitJump);
            }
        } else
        {
            Debug.Log("Frozen");
            if (Player_Help.finished)
            {
                Debug.Log("unfrozen");
            }
        }  
    }

    void waitToJump()
    {
        canJump = true;
    }

}

