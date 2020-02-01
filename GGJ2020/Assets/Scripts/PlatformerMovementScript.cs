using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovementScript : MonoBehaviour
{

    public float speed = 10;

    public bool jumpEnabled;

    public GameObject[] raycastOrigin;
    public float raycastLength = 0.01f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(raycastOrigin == null)
        {
            Debug.LogError("Please reference the raycast origin game object in the Platformer movement script");
        }

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);


        if(Input.GetKeyDown(KeyCode.Space) && jumpEnabled)
        {
            AttemptJump();
            
        }
    }

    public void setJumpEnabled(bool isEnabled)
    {
        jumpEnabled = isEnabled;
    }

    void AttemptJump()
    {
        print(canJump());
        if(canJump())
        {
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
}
