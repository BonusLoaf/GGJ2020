using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovementScript : MonoBehaviour
{

    public float speedModifyer;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(x, y) * speedModifyer;

    }
}
