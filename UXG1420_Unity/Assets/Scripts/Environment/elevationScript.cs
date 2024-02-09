using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class elevationScript : MonoBehaviour
{
    public float height;
    public GameObject floorCollision;

    private float maxSpeed = 150;
    private float fallSpeed = 2f;
    private float internalCounterSpeed = 0.1f;
    private float internalCounter = 0;
    private bool countEnabler = false;

    // variable to store the object that entered 
    private Collider2D collidingObject;

    // grabbing the collision2D attached
    private Collider2D floorCollider; 


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
        //when count is enabled, it will start minusing from the count.
        if (countEnabler == true)
        {
            internalCounter -=  internalCounterSpeed ; 
            
            //slow ramp of falling speed with a speed limit
            collidingObject.GetComponent<Rigidbody2D>().gravityScale = Mathf.Clamp(collidingObject.GetComponent<Rigidbody2D>().gravityScale * fallSpeed, 0, maxSpeed);
            
            //stop when counter hit 0
            if (internalCounter <= 0) 
            { 
                stopFall(collidingObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited");
        //on object exiting, will start falling
        if (collidingObject.GetComponent<playerHandler>().height >= height)
        {
            startFall(collidingObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("staying");
        if (collidingObject.GetComponent<playerHandler>().height >= height)
            {
                floorCollision.GetComponentInParent<Collider2D>().enabled = false;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //on object entering, will store object
        collidingObject = collision;
        Debug.Log("entered");
    }

    public void startFall(Collider2D collision)
    {
        //set counter to the height of current level, set starting gravity to 3 and start counting down
        internalCounter = collidingObject.GetComponent<playerHandler>().height;
        collision.GetComponent<Rigidbody2D>().gravityScale = 3;
        countEnabler = true;
        
    }

    public void stopFall(Collider2D collision)
    {
        //reset gravity scale, reset character height to 0, stop and reseting 
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        collision.GetComponent<playerHandler>().height = 0;
        countEnabler = false;
        internalCounter = 0;
        floorCollision.GetComponentInParent<Collider2D>().enabled = true;
        collidingObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
}
