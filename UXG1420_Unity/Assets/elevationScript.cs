using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevationScript : MonoBehaviour
{
    public float height;


    private Collider2D floorCollider;
    private float internalCounter = 0;
    private bool countEnabler = false;
    private Collision2D collidingObject;

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
            internalCounter -= 0.1f;
            if (internalCounter == 0)
            {
                stopFall(collidingObject);
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    { 
        if (collidingObject.gameObject.GetComponent<playerHandler>().height >= this.height)
        {
            startFall(collision);
            //collidingObject.height
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidingObject = collision;
    }

    public void startFall(Collision2D collision)
    {
        internalCounter = collidingObject.gameObject.GetComponent<playerHandler>().height;
        collision.rigidbody.gravityScale = 100;
        countEnabler = true;
    }

    public void stopFall(Collision2D collision)
    {
        collision.rigidbody.gravityScale = 0;
        countEnabler = false;
        internalCounter = 0;
    }
}
