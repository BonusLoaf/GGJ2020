using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collision2D col)
    {
        if (col.transform.tag == "GlitchParticle")
        {
            print("Should send message");
            gc.SendMessage("UnlockNextMechanic");
        }
    }
}
