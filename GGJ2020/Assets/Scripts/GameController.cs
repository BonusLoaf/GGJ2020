using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    private static GameController instance;

    private int numberOfMechanicUnlocks;


    public static GameController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockNextMechanic()
    {
        numberOfMechanicUnlocks++;
        switch(numberOfMechanicUnlocks)
        {

        }
    }

}
