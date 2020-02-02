using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameController gc;
    public int lives;
    public HealthSystemUI UI;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        gc = GetComponent<GameController>();

        if(!UI)
        {
            Debug.Log("Warnig: UI Not found on the health system");    
        }
    }

    public void SetLives(int newLives)
    {
        lives = newLives;
    }

    public void loseLife()
    {
        lives--;
        updateHealthSystem();
    }

    public void updateHealthSystem()
    {
        updateUI();
        if(lives <= 0)
        {
            gc.SendMessage("playerDied");
        }
    }


    public void updateUI()
    {
        switch(lives)
        {
            case 3:
                UI.setFullHealth();
                break;
            case 2:
                UI.setHalfHealth();
                break;
            case 1:
                UI.setLittleHealth();
                break;
            case 0:
                UI.setNoHealth();
                break;
        }
    }

    // TEMP PLEASE DELETE UPDATE FUNCTION IF FOUND
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            loseLife();
        }
    }


}
