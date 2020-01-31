using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) { // Move diagonaly up right

        } else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) {  // Move diagonaly down right

        } else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) { // Move diagonaly down left

        } else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) { // Move diagonaly up left

        } else if(Input.GetKey(KeyCode.W)) { // Move Up

        } else if (Input.GetKey(KeyCode.D)) { // Move right

        } else if (Input.GetKey(KeyCode.S)) { // Move down

        } else if (Input.GetKey(KeyCode.A)) { // Move left

        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rigibody.velocity = new Vector2(x, y) * 10;

    }
}
