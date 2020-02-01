using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovementScript : MonoBehaviour
{

    public float speed = 10;

    public bool jumpEnabled;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
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
        rb.velocity = new Vector2(0, 10);
    }
}
