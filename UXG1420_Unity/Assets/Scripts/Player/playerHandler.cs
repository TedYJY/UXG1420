using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{

    //Movement assignment
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    //possession assignments
    private GameObject cameraRef;
    private GameObject currentPlayer;
    private GameObject targetedPlayer;
    private GameObject ghostPlayer;
    private bool targetIsNearby;

    // Start is called before the first frame update
    void Start()
    {
        //Assign rb to player's Rigidbody2D
        rb = this.gameObject.GetComponent<Rigidbody2D>();


        //Assign posession gameObjects
        targetedPlayer = null;
        targetIsNearby = false;
        cameraRef = GameObject.FindWithTag("MainCamera");


    }

    // Update is called once per frame
    void Update()
    {
        //GetInput for movement keys, WASD, Arrows, Controller etc.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        //Disables diagonal movement
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }

        //Checks keydown to start possession method
        if (Input.GetKeyDown("e"))
        {
            AttemptPossession();
        }

    }

    void FixedUpdate()
    {
        //Movement using RigidBody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void AttemptPossession()
    {
        //Only runs if when you are the ghost, and else if you are the BigPlayer
        if (targetIsNearby == true)
        {
            //Change to nearby character

            //Set camera to look at new player
            cameraRef.GetComponent<cameraTracking>().target = targetedPlayer.transform;

            //Enable Collider for the new player
            targetedPlayer.GetComponent<CapsuleCollider2D>().enabled = true;

            //Enable playerHandler script for new player
            targetedPlayer.GetComponent<playerHandler>().enabled = true;

            //Change currentPlayer variable in new player's script to the new player
            targetedPlayer.GetComponent<playerHandler>().currentPlayer = targetedPlayer;

            //Change ghostPlayer in new player's script to the ghost
            targetedPlayer.GetComponent<playerHandler>().ghostPlayer = this.gameObject;

            //Disable box collider (trigger) for the outlining
            targetedPlayer.GetComponent<BoxCollider2D>().enabled = false;

            //Sets targetIsNearby to false, to prevent accidental triggering
            targetIsNearby = false;

            //Disables the ghost
            this.gameObject.SetActive(false);
        }

        else if (this.gameObject.tag == ("BigPlayer") && targetIsNearby == false)
        {
            //Change into ghost

            //Sets ghost's coordinates to the currentPlayer's coordinates
            ghostPlayer.transform.position = currentPlayer.transform.position;

            //Set camera to look at ghost player
            cameraRef.GetComponent<cameraTracking>().target = ghostPlayer.transform;

            //Disable BigPlayer's collider (MIGHT CHANGE FOR THE WIND FAN)
            currentPlayer.GetComponent<CapsuleCollider2D>().enabled = false;

            //Enable trigger for outlining
            currentPlayer.GetComponent<BoxCollider2D>().enabled = true;

            //Disables playerHandler script for bear
            currentPlayer.GetComponent<playerHandler>().enabled = false;

            //Enables the ghost
            ghostPlayer.SetActive(true);
        }
    }

    //Used to outline the BigPlayer (Script has been separated due to disabling playerHandler script, use this as setter to access private variables)
    public void outlineNearby(GameObject target)
    {
        targetIsNearby = !targetIsNearby;
        targetedPlayer = target;
    }

}
