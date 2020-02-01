using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collected() // Things to do once collected
    {
        // play collected animation/particle effect

        destroy();
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }

    public void MoveToPlayer()
    {
        GetComponent<Rigidbody2D>().gravityScale = -1;
    }
}
