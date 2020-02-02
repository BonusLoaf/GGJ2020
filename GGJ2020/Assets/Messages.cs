using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public Image text;

    public Sprite tuckspin;
    public Sprite terrain;
    public Sprite colours;
    public Sprite gravity;
    public Sprite movement;
    public Sprite jump;
    public Sprite tuckDetails;
    public Sprite face;
    public Sprite emotions;
    public Sprite enemies;
    public Sprite body;
    public Sprite camera;
    public Sprite health;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hide()
    {
        //Destroy(cText);
        text.color = Color.clear;
    }

    public void setMovement()
    {
        text.color = Color.white;
        text.sprite = movement;

        Invoke("hide", 3f);
    }
    public void setGravity()
    {
        text.color = Color.white;
        text.sprite = gravity;

        Invoke("hide", 3f);
    }
    public void setCamera()
    {
        text.color = Color.white;
        text.sprite = camera;

        Invoke("hide", 3f);
    }
    public void setJump()
    {
        text.color = Color.white;
        text.sprite = jump;

        Invoke("hide", 3f);
    }
    public void setFace()
    {
        text.color = Color.white;
        text.sprite = face;

        Invoke("hide", 3f);
    }
    public void setEmotions()
    {
        text.color = Color.white;
        text.sprite = emotions;

        Invoke("hide", 3f);
    }
    public void setHealth()
    {
        text.color = Color.white;
        text.sprite = health;

        Invoke("hide", 3f);
    }
    public void setEnemies()
    {
        text.color = Color.white;
        text.sprite = enemies;

        Invoke("hide", 3f);
    }
    public void setColour()
    {
        text.color = Color.white;
        text.sprite = colours;

        Invoke("hide", 3f);
    }
    public void setBody()
    {
        text.color = Color.white;
        text.sprite = body;

        Invoke("hide", 3f);
    }
    public void setTuckspin()
    {
        text.color = Color.white;
        text.sprite = tuckspin;

        Invoke("hide", 3f);
    }
    public void setDetail()
    {
        text.color = Color.white;
        text.sprite = terrain;

        Invoke("hide", 3f);
    }

}
