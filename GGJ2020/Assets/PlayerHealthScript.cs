using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public HealthSystem HS;

    private void Start()
    {
        HS = GetComponentInParent<PlayerScript>().gc.GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == ("Enemy"))
        {
            HS.loseLife();
        }
    }
}
