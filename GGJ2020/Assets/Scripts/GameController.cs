using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;


    public int numberOfMechanicUnlocks = 0;


    public Vector2 checkpointPos;

    private void checkMechs()
    {
        //numberOfMechanicUnlocks = PlayerPrefs.GetInt("mechanics");

        UnlockNextMechanic(0);
    }

    // Start is called before the first frame update
    void Start()
    {




        //Invoke("checkMechs", 0.1f);


        UnlockNextMechanic(0);
        
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
        if(Input.GetKeyDown(KeyCode.L))
        {
            UnlockNextMechanic(1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerDied();
        }
    }

    public void UnlockNextMechanic(int add)
    {
        numberOfMechanicUnlocks = numberOfMechanicUnlocks + add;


        if(numberOfMechanicUnlocks >= 1) // unlocks movement
        {

            print("Movement Unlocked");
            player.SendMessage("enableTopDownControlls");
            //PlayerPrefs.SetInt("mechanics", numberOfMechanicUnlocks);
            
        }
        if(numberOfMechanicUnlocks >= 2) // unlocks gravity (switches to platformer script)
        {
            print("Gravity Unlocked");
            player.SendMessage("disableTopDownControlls");
            player.SendMessage("enableGravity");
        }
        if (numberOfMechanicUnlocks >= 3) // unlocks camera following
        {
            print("Camera Fixed");
            player.SendMessage("enablePlatformerControlls");
            mainCamera.SendMessage("setFollowEnabled", true);
        }
        if (numberOfMechanicUnlocks >= 4) // unlocks jumping
        {
            print("Jumping unlocked");
            player.SendMessage("setAbilityToJump", true);
        }
        if (numberOfMechanicUnlocks >= 5) // unlocks jumping
        {
            print("Face Unlocked");
            player.SendMessage("setFace");
        }
        if (numberOfMechanicUnlocks >= 6) // unlocks jumping
        {
            print("Emotions Unlocked");
            player.SendMessage("setOwO");
        }

    }

    public void playerDied()
    {
        print("You died");

        StartCoroutine("respawn");
        
    }


    public void setCheckpointPos(Vector2 newPos)
    {
        checkpointPos = newPos;
    }




    IEnumerator respawn()
    {
        yield return new WaitForSeconds(5);

        if (checkpointPos != Vector2.zero) // If the player has reached a checkpoint
        {
            player.transform.position = checkpointPos;
        }
        else // If the player hasnt reached a checkpoint
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
