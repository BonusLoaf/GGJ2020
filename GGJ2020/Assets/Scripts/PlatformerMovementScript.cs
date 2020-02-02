using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovementScript : MonoBehaviour
{

    public Animator emotions;

    public float speed = 10;
    public float dashVerticalSpeed;
    public float dashSpeed = 20f;

    public bool jumpEnabled;
    public bool dashEnabled;


    public bool canWalk;
    private bool hasDashed;

    public GameObject[] raycastOrigin;
    public float raycastLength = 0.01f;

    // Only for once the player has unlocked the characters full body
    public GameObject characterBody;
    public GameObject characterRollingBody;
    public SpriteRenderer characterFace;

    public PhysicsMaterial2D normalMat;
    public PhysicsMaterial2D bouncyMat;

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


        if((dashEnabled && characterBody && characterRollingBody && characterFace))
        {
            switchToNormalBody();
            
        } else
        {
            Debug.LogError("Error: dashing is enabled and no reference to the characters full body/ rolling child gameobject is found");
        }
        if(!(dashEnabled && normalMat && bouncyMat))
        {
            Debug.LogError("Error: dashing is enabled and no reference to the bouncy and normal physics material are found");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(canWalk)
        {
            float x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(x * speed, rb.velocity.y);

            if(Input.GetAxisRaw("Horizontal") >= 0.5f)
            {
                emotions.SetTrigger("Right");
            }
            if (Input.GetAxisRaw("Horizontal") <= -0.5f)
            {
                emotions.SetTrigger("Left");
            }
            if (Input.GetAxisRaw("Horizontal") == 0f)
            {
                emotions.SetTrigger("Centre");
            }

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
            emotions.SetTrigger("Jump");
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
        switchToRollingBody();
        

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
        } else
        {
            rb.AddForce(Vector3.up * dashSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        rb.sharedMaterial = bouncyMat;

        bounces = 0;
        hasDashed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounces++;

        if(bounces >= 4)
        {
            canWalk = true;
            rb.sharedMaterial = normalMat;
            switchToNormalBody();
        }
    }

    public void switchToNormalBody()
    {
        if(characterBody && characterRollingBody && characterFace)
        {
            characterFace.enabled = true;
            characterBody.SetActive(true);
            characterRollingBody.SetActive(false);
        } else
        {
            Debug.LogError("Error: attempting to switch to normal body but no reference to the characters full body/ rolling child gameobject is found");
        }
    }

    public void switchToRollingBody()
    {
        if (characterBody && characterRollingBody && characterFace)
        {
            characterFace.enabled = false;
            characterBody.SetActive(false);
            characterRollingBody.SetActive(true);
        } else 
        {
            Debug.LogError("Error: attempting to switch to rolling body but no reference to the characters full body/ rolling child gameobject is found");
        }
    }
}
