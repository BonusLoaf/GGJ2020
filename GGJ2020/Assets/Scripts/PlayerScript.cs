using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gc;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TopDownMovementScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GlitchParticle") // collected glitch particle
        {
            gc.SendMessage("UnlockNextMechanic");
            col.SendMessage("collected");
        }
    }

    public void enableTopDownControlls()
    {
        gameObject.GetComponent<TopDownMovementScript>().enabled = true;
    }
}
