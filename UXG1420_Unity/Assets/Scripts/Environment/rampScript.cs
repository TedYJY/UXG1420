using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float exitHeight; 
    public float enterHeight;
    public Collider2D exitCollider;
    public Collider2D entryCollider;
    public GameObject floorCollision;

    private GameObject collidingObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidingObject = collision.gameObject;

        floorCollision.GetComponent<Collider2D>().enabled = false;

        if (exitCollider != null)
        {
            collidingObject.GetComponent<playerHandler>().height = exitHeight;
            collidingObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else
        {
            collidingObject.GetComponent<playerHandler>().height = enterHeight;
            collidingObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        floorCollision.GetComponent<Collider2D>().enabled = true;

    }
}
