using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    private Draggable draggedobj;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (draggedobj != null)
            {
                draggedobj.SetIsDragged(false);
                draggedobj = null;
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider == null) return;            

            Draggable drag = hit.collider.gameObject.GetComponent<Draggable>();

            if (drag == null) return;

            if (draggedobj != null) draggedobj.SetIsDragged(false);

            draggedobj = drag;
            draggedobj.SetIsDragged(true);
        }
    }

    public void ClearDraggedObj()
    {
        draggedobj = null;
    }
}
