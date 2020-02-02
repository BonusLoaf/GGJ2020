using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameController gc;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        gc = GetComponent<GameController>();
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
        print(lives);
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
