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
    private float smoothTime = 2f;

    //
    [Header("Initial camera timings")]
    [SerializeField]
    private float initialPauseTime = 1f;
    [SerializeField]
    private float initialResumeTime = 4.8f;

    [Header("Camera boundaries")]
    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float topLimit;


    private void Start()
    {
        Invoke("findGhost", initialPauseTime);
        //Debug.Log("Ghost found for camera");

        Invoke("fasterCam", initialResumeTime);
        

    }

    void FixedUpdate()
    {
        try
        {
            Vector3 targetPos = target.position;

            //align the camera and the target z position
            targetPos.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);


            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
        }
        catch
        {
            //Debug.Log("Camera has stopped")
        }

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

    void findGhost()
    {
        target = GameObject.FindWithTag("Ghost").transform;
    }
    private void fasterCam()
    {
        smoothTime = 0.15f;
    }

}