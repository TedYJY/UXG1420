using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outline : MonoBehaviour
{

    public SpriteRenderer outlineColor;

    public GameObject currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ghost")
        {
            //Outlines the nearby player
            outlineColor.color = Color.red;

            //Tags the current player and changes condition of "swapping" script to enable possessing
            currentPlayer = col.gameObject;
            currentPlayer.GetComponent<swapping>().targetIsNearby = true;
            currentPlayer.GetComponent<swapping>().targetedPlayer = this.gameObject;
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ghost")
        {
            outlineColor.color = Color.white;
            currentPlayer.GetComponent<swapping>().targetIsNearby = false;
            currentPlayer.GetComponent<swapping>().targetedPlayer = null;
            currentPlayer = null;
        }

    }
}
