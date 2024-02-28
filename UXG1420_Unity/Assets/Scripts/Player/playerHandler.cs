using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{
    //Height assignemnt
    public float height = 1f;

    //Movement assignment
    private float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;

    //Possession assignments
    private GameObject cameraRef;
    private GameObject UIRef;

    [SerializeField]
    private GameObject currentPlayer;
    [SerializeField]
    private GameObject targetedPlayer;
    [SerializeField]
    private GameObject ghostPlayer;
    [SerializeField]
    private bool targetIsNearby;

    //Animation assignment
    private Animator animator;
    private bool IsFacingLeft = false;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Assign rb to player's Rigidbody2D
        rb = this.gameObject.GetComponent<Rigidbody2D>();


        //Assign posession gameObjects
        targetedPlayer = null;
        targetIsNearby = false;
        cameraRef = GameObject.FindWithTag("MainCamera");
        UIRef = GameObject.FindWithTag("UI");

        //Assign animator of player
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //GetInput for movement keys, WASD, Arrows, Controller etc.
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //movement = movement.normalized;

        //Disables diagonal movement
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }

        //Sends values to animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("Pushing", false);
        }

        if (movement.x > 0.01)
        {
            animator.SetFloat("IdleHorizontal", 1);
            IsFacingLeft = false;
            animator.SetFloat("IdleVertical", 0);
        }

        else if (movement.y > 0.01)
        {
            animator.SetFloat("IdleVertical", 1);
            animator.SetFloat("IdleHorizontal", 0);
        }

        else if (movement.x < -0.01)
        {
            animator.SetFloat("IdleHorizontal", -1);
            IsFacingLeft = true;
            animator.SetFloat("IdleVertical", 0);
        }

        else if (movement.y < -0.01)
        {
            animator.SetFloat("IdleVertical", -1);
            animator.SetFloat("IdleHorizontal", 0);
        }

        //Checks keydown to start possession method
        if (Input.GetKeyDown("e"))
        {
            AttemptPossession();
        }

        if (IsFacingLeft == true)
        {
            spriteRenderer.flipX = true;
        }

        else { spriteRenderer.flipX = false; }
    }

    void FixedUpdate()
    {
        //Movement using RigidBody2D
        rb.MovePosition(rb.position  + movement * moveSpeed * Time.fixedDeltaTime);

    }

    private void AttemptPossession()
    {
        //Only runs if when you are the ghost, and else if you are the BigPlayer
        if (targetIsNearby == true)
        {
            //Change to nearby character

            //Set camera to look at new player
            cameraRef.GetComponent<cameraTracking>().ChangeTarget(targetedPlayer);

            //Set UI to look at new player
            try
            {
                UIRef.GetComponent<cameraTracking>().ChangeTarget(targetedPlayer);
            }

            catch 
            {
                Debug.Log("No UI Found");
            }


            targetedPlayer.GetComponent<Animator>().enabled = true;

            //Enable Collider for the new player
            targetedPlayer.GetComponent<BoxCollider2D>().enabled = true;

            //Enable playerHandler script for new player
            targetedPlayer.GetComponent<playerHandler>().enabled = true;

            //Change currentPlayer variable in new player's script to the new player
            targetedPlayer.GetComponent<playerHandler>().currentPlayer = targetedPlayer;

            //Change ghostPlayer in new player's script to the ghost
            targetedPlayer.GetComponent<playerHandler>().ghostPlayer = this.gameObject;

            //Disable Capsule collider (trigger) for the outlining
            targetedPlayer.GetComponent<CapsuleCollider2D>().enabled = false;

            

            //Sets targetIsNearby to false, to prevent accidental triggering
            targetIsNearby = false;

            //Disables the ghost
            this.gameObject.SetActive(false);

            try
            {
                UIRef.SetActive(false);
            }

            catch
            {
                Debug.Log("UI Prompt Already Inactive");
            }
        }

        else if (this.gameObject.tag == ("BigPlayer") && targetIsNearby == false)
        {
            //Change into ghost

            //Sets ghost's coordinates to the currentPlayer's coordinates
            ghostPlayer.transform.position = currentPlayer.transform.position;

            //Set camera to look at ghost player
            cameraRef.GetComponent<cameraTracking>().ChangeTarget(ghostPlayer);

            //Disable BigPlayer's collider (MIGHT CHANGE FOR THE WIND FAN)
            currentPlayer.GetComponent<BoxCollider2D>().enabled = false;

            currentPlayer.GetComponent <Animator>().enabled = false;

            //Enable trigger for outlining
            currentPlayer.GetComponent<CapsuleCollider2D>().enabled = true;

            //Disables playerHandler script for bear
            currentPlayer.GetComponent<playerHandler>().enabled = false;

            //Enables the ghost
            ghostPlayer.SetActive(true);

            ghostPlayer.GetComponent<playerHandler>().targetIsNearby = false;
        }
    }

    //Used to outline the BigPlayer (Script has been separated due to disabling playerHandler script, use this as setter to access private variables)
    public void outlineNearby(GameObject target, bool isTargetNearby)
    {
        targetIsNearby = isTargetNearby;
        targetedPlayer = target;

        try
        {
            UIRef.GetComponent<UIScripts>().TurnEActive();
        }

        catch
        {

        }
    }

    public void attemptFall(GameObject floor)
    {

    }

    public GameObject grabCurrentPlayer()
    {
        return currentPlayer;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Detect collision for pushing animation
        if (collision.gameObject.tag == "Rock" && movement.sqrMagnitude > 0.01)
        {
            animator.SetBool("Pushing", true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        //Detect collision for pushing animation
        if (collision.gameObject.tag == "Rock")
        {
            animator.SetBool("Pushing", false);
        }
    }
}
