using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryParticleRandomise : MonoBehaviour
{

    private int number;
    public Material[] materials = new Material[2]; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        number = Random.Range(0, 2);
        Debug.Log(number);
        WaitAndChange(number);
    }

    private IEnumerator WaitAndChange(int nextNumber)
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<ParticleSystemRenderer>().material = materials[nextNumber];
        
    }
}
