using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragged;
    [SerializeField] int pieceNum;

    private bool isDraggable = true;

    private MousePointer mp;


    // Start is called before the first frame update
    void Start()
    {
        mp = GameObject.Find("GameController").GetComponent<MousePointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDragged) return;

        
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.1f;

        transform.position = pos;
    }

    public void SetIsDragged(bool isDragged)
    {
        if (isDraggable)
        {
            this.isDragged = isDragged;
        }        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "DropZone")
        {
            print("Dropped");

            Transform snap = col.gameObject.transform.GetChild(pieceNum - 1);

            transform.parent = col.transform;
            transform.position = snap.position;

            SetIsDragged(false);
            isDraggable = false;

            GetComponent<Collider2D>().enabled = false;
            mp.SendMessage("ClearDraggedObj");
        }
    }
}
