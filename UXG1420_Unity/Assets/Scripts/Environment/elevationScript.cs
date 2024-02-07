using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class elevationScript : MonoBehaviour
{
    public float height;

    private float maxSpeed = 150;
    private float fallSpeed = 2f;
    private float internalCounterSpeed = 0.1f;
    private Collider2D floorCollider;
    private float internalCounter = 0;
    private bool countEnabler = false;
    private Collider2D collidingObject;
    

    // Start is called before the first frame update
    void Start()
    {
        floorCollider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (countEnabler == true)
        {
            internalCounter -=  internalCounterSpeed ;//Time.deltaTime;
            collidingObject.GetComponent<Rigidbody2D>().gravityScale = Mathf.Clamp(collidingObject.GetComponent<Rigidbody2D>().gravityScale * fallSpeed, 0, maxSpeed);
            if (internalCounter <= 0) 
            { 
                stopFall(collidingObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited");
        //if (collision.gameObject.GetComponent<playerHandler>().height == this.height)
        if (collidingObject.GetComponent<playerHandler>().height >= height)
        {
            startFall(collidingObject);
            //collidingObject.height
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidingObject = collision;
        Debug.Log("entered");
    }

    public void startFall(Collider2D collision)
    {
        internalCounter = collidingObject.GetComponent<playerHandler>().height;
        collision.GetComponent<Rigidbody2D>().gravityScale = 3;
        countEnabler = true;
    }

    public void stopFall(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        collision.GetComponent<playerHandler>().height = 0;
        countEnabler = false;
        internalCounter = 0;
    }
}
