using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {



    }

    private void Awake()
    {
        PlayerPrefs.SetInt("mechanics", 0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
