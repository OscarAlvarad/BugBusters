using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;
    bool isJump = false;
    bool canJump = true;

    public Rigidbody2D rb;
    public float speedForce;
    public float jumpForce;
    public float waitJump;
    public Animator anim;
    public SpriteRenderer spr;

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
    }

    void waitToJump()
    {
        canJump = true;
    }

}

