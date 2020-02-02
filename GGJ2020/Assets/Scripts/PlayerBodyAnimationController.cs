using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyAnimationController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator a;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        a.SetFloat("X", Input.GetAxisRaw("Horizontal"));
        a.SetFloat("Y", rb.velocity.y);

    }
}
