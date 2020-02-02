using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;

    public GameObject glitchWall0;
    public GameObject glitchWall1;
    public GameObject glitchWall2;
    public GameObject platforms;
    public GameObject rainbow;
    public GameObject sky;
    public GameObject skyline;
    public GameObject hill;

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

        if(sky)
        sky.SetActive(false);


        if (skyline)
        skyline.SetActive(false);


        if (hill)
            hill.SetActive(false);

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

            if(glitchWall0)
            glitchWall0.active = false;

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
        if(numberOfMechanicUnlocks >= 7)
        {
            print("Health Unlocked");

            if (glitchWall1)
                glitchWall1.active = false;
        }
        if (numberOfMechanicUnlocks >= 8)
        {
            print("Enemies Unlocked");

            if(glitchWall2)
            glitchWall2.active = false;
        }
        if (numberOfMechanicUnlocks >= 9)
        {
            print("Body Unlocked");


        }
        if (numberOfMechanicUnlocks >= 10)
        {
            print("Colour Unlocked");

            Color ground = new Color(0.52f, 1f, 0.31f);

            sky.SetActive(true);
            platforms.GetComponent<SpriteRenderer>().color = ground;
            rainbow.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (numberOfMechanicUnlocks >= 11)
        {
            print("Tuckspin Unlocked");


        }
        if (numberOfMechanicUnlocks >= 12)
        {
            print("Detail Unlocked");


            hill.SetActive(true);
            skyline.SetActive(true);
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
        yield return new WaitForSeconds(0);

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
