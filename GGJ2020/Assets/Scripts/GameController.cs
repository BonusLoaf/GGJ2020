using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    private static GameController instance;

    private int numberOfMechanicUnlocks;


    public static GameController Instance {
        get
        {
            if (instance == null)
            {
                instance = new GameController();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockNextMechanic()
    {
        numberOfMechanicUnlocks++;
        print(numberOfMechanicUnlocks);
        switch(numberOfMechanicUnlocks)
        {
            case 1:
                print("Movement Unlocked");
                player.SendMessage("enableTopDownControlls");
                break;
        }
    }

}
