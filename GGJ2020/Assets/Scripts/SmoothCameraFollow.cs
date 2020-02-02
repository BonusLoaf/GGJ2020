using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothCameraFollow : MonoBehaviour
{
    public bool followEnabled;

    public float followSpeed = 2f;

    public Transform target;

    private Camera camera;

    public Image staticImg;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<Camera>()) {
            camera = gameObject.GetComponent<Camera>();
        } else
        {
            Debug.LogError("No camera found on this game object");
        }
        if(staticImg)
        {
            staticImg.color = new Color(1f, 1f, 1f, 0f);
        }
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(target && followEnabled)
        {
            Vector3 targetPos = target.position;
            targetPos.z = -10;
            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }


    public void setFollowEnabled(bool newFollowIn)
    {
        print("setFollowEnabled(bool newFollowIn)");
        followEnabled = newFollowIn;
    }


    public void transition()
    {
        cameraShake();
        showStatic();
    }

    public void cameraShake()
    {
        gameObject.GetComponent<Animation>().Play();
    }

    public void showStatic()
    {
        if(staticImg)
        {
            staticImg.color = Color.white;
            StartCoroutine("clearStatic");
        } else
        {
            Debug.LogError("Error: static image is not found on smooth camear follow");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            transition();
        }
    }

    IEnumerator clearStatic()
    {
        yield return new WaitForSeconds(0.5f);

        staticImg.color = new Color(1f, 1f, 1f, 0f);
        cameraShake();
    }
}
