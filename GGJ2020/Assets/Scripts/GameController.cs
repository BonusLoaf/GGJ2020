using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject fullPlayer;
    public GameObject mainCamera;
    public GameObject health;

    public GameObject UI;
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

        if (health)
          health.SetActive(false);


        if (sky)
        sky.SetActive(false);


        if (skyline)
        skyline.SetActive(false);


        if (hill)
            hill.SetActive(false);


        if (fullPlayer)
            fullPlayer.SetActive(false);

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
            UI.SendMessage("setMovement");
            print("Movement Unlocked");
            player.SendMessage("enableTopDownControlls");
            //PlayerPrefs.SetInt("mechanics", numberOfMechanicUnlocks);
            
        }
        if(numberOfMechanicUnlocks >= 2) // unlocks gravity (switches to platformer script)
        {


            UI.SendMessage("setGravity");
            print("Gravity Unlocked");
            
            player.SendMessage("disableTopDownControlls");
            player.SendMessage("enableGravity");

            if(glitchWall0)
            glitchWall0.active = false;

        }
        if (numberOfMechanicUnlocks >= 3) // unlocks camera following
        {

            UI.SendMessage("setCamera");
            print("Camera Fixed");
            player.SendMessage("enablePlatformerControlls");
            mainCamera.SendMessage("setFollowEnabled", true);
        }
        if (numberOfMechanicUnlocks >= 4) // unlocks jumping
        {

            UI.SendMessage("setJump");
            print("Jumping unlocked");
            player.SendMessage("setAbilityToJump", true);
        }
        if (numberOfMechanicUnlocks >= 5) // unlocks jumping
        {

            UI.SendMessage("setFace");
            print("Face Unlocked");
            player.SendMessage("setFace");
        }
        if (numberOfMechanicUnlocks >= 6) // unlocks jumping
        {

            UI.SendMessage("setEmotions");
            print("Emotions Unlocked");
            player.SendMessage("setOwO");
        }
        if(numberOfMechanicUnlocks >= 7)
        {

            UI.SendMessage("setHealth");

            print("Health Unlocked");

            health.SetActive(true);

            if (glitchWall1)
                glitchWall1.active = false;
        }
        if (numberOfMechanicUnlocks >= 8)
        {


            UI.SendMessage("setEnemies");
            print("Enemies Unlocked");

            if(glitchWall2)
            glitchWall2.active = false;
        }
        if (numberOfMechanicUnlocks >= 9)
        {


            UI.SendMessage("setColour");
            print("Colour Unlocked");

            Color ground = new Color(0.52f, 1f, 0.31f);

            sky.SetActive(true);
            platforms.GetComponent<SpriteRenderer>().color = ground;
            rainbow.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (numberOfMechanicUnlocks >= 10)
        {

            UI.SendMessage("setBody");

            print("Body Unlocked");
            fullPlayer.SetActive(true);
            player.SetActive(false);
            
            fullPlayer.SendMessage("setFace");
            fullPlayer.SendMessage("setOwO");
            mainCamera.GetComponent<SmoothCameraFollow>().target = fullPlayer.transform;
            fullPlayer.SendMessage("setDash", false);
        }
        if (numberOfMechanicUnlocks >= 11)
        {


            UI.SendMessage("setTuckspin");
            print("Tuckspin Unlocked");
            fullPlayer.SendMessage("setDash", true);
            mainCamera.GetComponent<SmoothCameraFollow>().target = fullPlayer.transform;
            fullPlayer.SendMessage("setFace");
            fullPlayer.SendMessage("setOwO");

        }
        if (numberOfMechanicUnlocks >= 12)
        {


            UI.SendMessage("setDetail");
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
        yield return new WaitForSeconds(0.5f);

        if (checkpointPos != Vector2.zero) // If the player has reached a checkpoint
        {
            player.transform.position = checkpointPos;
            GetComponent<HealthSystem>().SetLives(3);
        }
        else // If the player hasnt reached a checkpoint
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
