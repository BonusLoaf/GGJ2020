using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public bool followEnabled;

    public float followSpeed = 2f;

    public Transform target;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<Camera>()) {
            camera = gameObject.GetComponent<Camera>();
        } else
        {
            Debug.LogError("No camera found on this game object");
        }

        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(target && followEnabled)
        {
            Vector3 targetPos = target.position;
            targetPos.z = -10;
            transform.position = Vector3.Slerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }


    public void setFollowEnabled(bool newFollowIn)
    {
        print("setFollowEnabled(bool newFollowIn)");
        followEnabled = newFollowIn;
    }
}
