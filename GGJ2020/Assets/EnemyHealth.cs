using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kill()
    {
        // PLAY NOISE
        print("Kill()");
        Destroy(this.gameObject);
    }

    /*private void (Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            kill();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            kill();
        }
    }
}
