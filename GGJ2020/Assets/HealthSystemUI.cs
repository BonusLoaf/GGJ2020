using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemUI : MonoBehaviour
{

    public Sprite fullHealth;
    public Sprite halfHealth;
    public Sprite littleHealth;
    public Sprite dead;

    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        img.sprite = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFullHealth()
    {
        img.sprite = fullHealth;
    }

    public void setHalfHealth()
    {
        img.sprite = halfHealth;
    }

    public void setLittleHealth()
    {
        img.sprite = littleHealth;
    }

    public void setNoHealth()
    {
        img.sprite = dead;
    }
}
