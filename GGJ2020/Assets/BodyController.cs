using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public SpriteRenderer Arm_L;
    public SpriteRenderer Arm_R;
    public SpriteRenderer Body;
    public SpriteRenderer Ear_L;
    public SpriteRenderer Ear_R;
    public SpriteRenderer Head;
    public SpriteRenderer Leg_L;
    public SpriteRenderer Leg_R;
    public SpriteRenderer Tail;

    public SpriteRenderer Face;

    public BoxCollider2D col;



    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        Face = gameObject.transform.Find("Face").GetComponent<SpriteRenderer>();

        Arm_L = gameObject.transform.Find("Arm_L").GetComponent<SpriteRenderer>();
        Arm_R = gameObject.transform.Find("Arm_R").GetComponent<SpriteRenderer>();
        Body = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        Ear_L = gameObject.transform.Find("Ear_L").GetComponent<SpriteRenderer>();
        Ear_R = gameObject.transform.Find("Ear_R").GetComponent<SpriteRenderer>();
        Head = gameObject.transform.Find("Head").GetComponent<SpriteRenderer>();
        Leg_L = gameObject.transform.Find("Leg_L").GetComponent<SpriteRenderer>();
        Leg_R = gameObject.transform.Find("Leg_R").GetComponent<SpriteRenderer>();
        Tail = gameObject.transform.Find("Tail").GetComponent<SpriteRenderer>();
    }

    
    public void hideCharacter()
    {
        print("HideCharacter();");
        col.enabled = false;
        Face.enabled = false;
        Arm_L.enabled = false;
        Arm_R.enabled = false;
        Body.enabled = false;
        Ear_L.enabled = false;
        Ear_R.enabled = false;
        Head.enabled = false;
        Leg_L.enabled = false;
        Leg_R.enabled = false;
        Tail.enabled = false;
    }

    public void showCharacter()
    {
        print("ShowCharacter();");
        col.enabled = true;
        Face.enabled = true;
        Arm_L.enabled = true;
        Arm_R.enabled = true;
        Body.enabled = true;
        Ear_L.enabled = true;
        Ear_R.enabled = true;
        Head.enabled = true;
        Leg_L.enabled = true;
        Leg_R.enabled = true;
        Tail.enabled = true;
    }
}
