using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixedAspectRatioScript : MonoBehaviour
{
    // Use this for initialization

    public GameObject mainCamera;

    // set the desired aspect ratio
    private float targetaspect = 16.0f / 9.0f;

    // determine the game window's current aspect ratio
    private float windowaspect = (float)Screen.width / (float)Screen.height;

    private float scaleheight;

    private new Camera camera;

    

    void Start()
    {

        // current viewport height should be scaled by this amount
         //scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        camera = mainCamera.GetComponent<Camera>();


    }

    private void Update()
    {
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        scaleheight = windowaspect / targetaspect;

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;

            Debug.Log("Rescaling Width");
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;

            Debug.Log("Rescaling Height");
        }
    }
}
