using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    private static GameController instance;

    private int numberOfMechanicUnlocks = 0;



    public static GameController Instance;

    private void checkMechs()
    {
        numberOfMechanicUnlocks = PlayerPrefs.GetInt("mechanics");

        UnlockNextMechanic(0);
    }

    // Start is called before the first frame update
    void Start()
    {


        

        Invoke("checkMechs", 0.1f);
        
        
    }


    private void Awake()
    {

        

        //Debug.Log(numberOfMechanicUnlocks);
        //if (instance == null)
        //{
        //    DontDestroyOnLoad(transform.gameObject);
        //    instance = this;
        //} else
        //{
        //    Destroy(gameObject);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockNextMechanic(int add)
    {
        numberOfMechanicUnlocks = numberOfMechanicUnlocks + add;
        print(numberOfMechanicUnlocks);


        if(numberOfMechanicUnlocks >= 1)
        {

            print("Movement Unlocked");
            player.SendMessage("enableTopDownControlls");
            PlayerPrefs.SetInt("mechanics", numberOfMechanicUnlocks);
            
        }
        if(numberOfMechanicUnlocks >= 2)
        {

            print("Gravity Unlocked");
            player.GetComponent<Rigidbody2D>().gravityScale = 1;


        }


    }

}
