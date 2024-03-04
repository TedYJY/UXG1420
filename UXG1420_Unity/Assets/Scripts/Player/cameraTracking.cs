using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracking : MonoBehaviour
{

    //what we are following
    private Transform target;

    //zeros out velocity
    Vector3 velocity = Vector3.zero;

    //time to follow target
    private float smoothTime = 2.5f;

    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float topLimit;


    private void Start()
    {
        target = GameObject.FindWithTag("Ghost").transform;
        Debug.Log("Ghost found for camera");

        Invoke("fasterCam", 6);
    }

    void FixedUpdate()
    {

        Vector3 targetPos = target.position;

        //align the camera and the target z position
        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
    }

    public void ChangeTarget(GameObject T)
    {
        target = T.transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));


    }

    private void fasterCam()
    {
        smoothTime = 0.15f;
    }
}