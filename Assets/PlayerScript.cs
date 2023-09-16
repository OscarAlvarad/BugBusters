using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool Left = false;
    bool Right = false;
    bool Top = false;
    bool Bottom = false;

    public Rigidbody2D rgb;
    public float movespeed;

    public void ClickLeft()
    {
        Left = true;
    }

    public void ReleaseLeft()
    {
        Left = false;
    }

    public void ClickRight()
    { 
        Right = true;
    }    
    public void ReleaseRight()
    {
        Right= false;
    }

    public void ClickTop()
    {
        Top = true;
    }

    public void ReleaseTop()
    {
        Top= false;
    }

    public void ClickBottom() 
    {
        Bottom = true;
    }

    public void ReleaseBottom() 
    {
        Bottom= false;
    }

    private void FixedUpdate()
    {
        if (Left)
        {
            rgb.AddForce(new Vector2 (-movespeed, 0) * Time.deltaTime);
        }

        if (Right) 
        {
            rgb.AddForce(new Vector2(movespeed, 0) * Time.deltaTime);
        }
        if(Top)
        {
            rgb.AddForce(new Vector2(0, movespeed) * Time.deltaTime);
        }
        if (Bottom)
        {
            rgb.AddForce(new Vector2(0, -movespeed) * Time.deltaTime);
        }
    }

}
