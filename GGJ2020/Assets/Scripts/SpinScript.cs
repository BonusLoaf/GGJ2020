using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject body;

    public float torque;
    private float modifyer;

    private void Start()
    {
    }

    private void Awake()
    {
        rb = this.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x <= -0.5f) // Spin left (anti-clockwise)
        {
            modifyer = 1;
        }
        else // Spin right (clockwise)
        {
            modifyer = -1;
        }
        transform.Rotate(0, 0, torque * modifyer * Time.deltaTime);
    }

    private void OnEnable()
    {
        if (!rb)
        {
            Debug.LogError("Error: SpinScript on characters spinbody cannot find the characters rigid body");
        }


        //print("rb.velocity.x: " + rb.velocity.x);
        
    }
}
