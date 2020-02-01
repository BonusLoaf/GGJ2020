using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gc;


    public Animator emotions;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<TopDownMovementScript>().enabled = false;

        //gameObject.GetComponent<PlatformerMovementScript>().enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GlitchParticle") // collected glitch particle
        {
            Vector2 pos = col.gameObject.transform.position;
            gc.SendMessage("UnlockNextMechanic", 1); // Tells game manager to unlock the next mechanic

            gc.SendMessage("setCheckpointPos", pos);

            col.SendMessage("collected"); // Tells the glitch particle its been collected
        }
    }

    public void enableGravity()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    public void disableGravity()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void enableTopDownControlls()
    {
        //gameObject.GetComponent<PlatformerMovementScript>().enabled = false;
        gameObject.GetComponent<TopDownMovementScript>().enabled = true;
    }

    public void disableTopDownControlls()
    {
        gameObject.GetComponent<TopDownMovementScript>().enabled = false;
    }

    public void enablePlatformerControlls()
    {
        gameObject.GetComponent<TopDownMovementScript>().enabled = false;
        gameObject.GetComponent<PlatformerMovementScript>().enabled = true;
    }

    public void setAbilityToJump(bool canJump)
    {
        gameObject.GetComponent<PlatformerMovementScript>().setJumpEnabled(canJump);
    }


    public void setFace()
    {

        emotions.SetTrigger("FaceUnlocked");

    }

    public void setOwO()
    {

        emotions.SetTrigger("EmotionsUnlocked");



    }
}
