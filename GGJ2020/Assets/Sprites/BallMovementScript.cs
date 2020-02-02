using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementScript : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        if(!rb)
        {
            Debug.LogError("Error: BallMovementScript on characters spinbody cannot find the characters rigid body");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) >= 0.25f)
        {
            rb.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
        }
    }
}
