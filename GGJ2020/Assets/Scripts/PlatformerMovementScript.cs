using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovementScript : MonoBehaviour
{

    public float speed = 10;
    public float dashVerticalSpeed;
    public float dashSpeed = 20f;

    public bool jumpEnabled;
    public bool dashEnabled;


    public bool canWalk;
    private bool hasDashed;

    public GameObject[] raycastOrigin;
    public float raycastLength = 0.01f;

    private int bounces;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        bounces = 0;
        canWalk = true;
        hasDashed = false;

        if(raycastOrigin == null)
        {
            Debug.LogError("Please reference the raycast origin game object in the Platformer movement script");
        }

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(canWalk)
        {
            float x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
        }
        

        if(Input.GetKeyDown(KeyCode.Space) && jumpEnabled)
        {

            if(dashEnabled && !hasDashed)
            {
                if(!canJump())
                {
                    // DASH
                    print("Dash");
                    dash();
                    
                } else
                {
                    AttemptJump();
                }
                 

            } else
            {
                AttemptJump();
            }
            
            
        }
    }

    public void setJumpEnabled(bool isEnabled)
    {
        jumpEnabled = isEnabled;
    }

    void AttemptJump()
    {
        //print(canJump());
        if(canJump())
        {
            hasDashed = false;
            rb.velocity = new Vector2(0, 10);
        }
        
    }





    private bool canJump() // Sends Raycast to check if the player is on the floor
    {
        //Debug.DrawRay(raycastOrigin.transform.position, Vector2.down * raycastLength, Color.green, 3f); // draws the raycast

        foreach (GameObject pos in raycastOrigin)
        {
            Debug.DrawRay(pos.transform.position, Vector2.down * raycastLength, Color.green, 3f); // draws the raycast
            RaycastHit2D hit = Physics2D.Raycast(pos.transform.position, Vector2.down, raycastLength);
            if (hit.collider != null)
            {
                return true;
            }
        }
        


        return false;
    }

    private void dash()
    {
        canWalk = false;
        

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            //print("Should dash + " + Input.GetAxisRaw("Horizontal"));

            rb.AddForce(Vector3.right * dashSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, ForceMode2D.Impulse);
            rb.AddForce(Vector3.up * dashVerticalSpeed * Time.deltaTime, ForceMode2D.Impulse);
            //Vector3 x = rb.velocity;
            //x += transform.right * Input.GetAxisRaw("Horizontal") * dashSpeed * Time.deltaTime;
            //rb.velocity = x;

        } else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            rb.AddForce(Vector3.up * dashSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"), ForceMode2D.Impulse);
        }


        bounces = 0;
        hasDashed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounces++;

        if(bounces >= 4)
        {
            canWalk = true;
        }
    }
}
