using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_3x3 : MonoBehaviour
{

    //Keeps track of surrounding pressure plates in 3x3
    public GameObject Top;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;

    //Keeps track of the state of the pressure plate
    public bool IsActivated = false;

    //Keeps track of when the player is able to press down the pressure plate
    public bool IsOnTop = false;

    //Keeps track of how many plates are activated
    public static int Tracker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for keydown, when player is colliding with trigger
        if (Input.GetKeyDown(KeyCode.F) && IsOnTop == true)
        {
            //Activates the pressure plate
            Activation();

            //Activates surrounding pressure plates
            ActivationSurrounding();
        }
    }

    //Activation method
    private void Activation()
    {
        //Checks if IsActivated is true, and changes the SpriteRenderer
        if (!IsActivated)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            IsActivated = true;
            Tracker++;
        }

        //Checks if IsActivated is false, and changes the SpriteRenderer
        else if (IsActivated)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            IsActivated = false;
            Tracker--;
        }

    }

    //Activate surrounding pressure plates method
    private void ActivationSurrounding()
    {

        //Checks if the GameObjects are pointing towards anything, to prevent errors
        if (Top != null)
        {
            Top.GetComponent<Puzzle_3x3>().Activation();
        }

        if (Down != null)
        {
            Down.GetComponent<Puzzle_3x3>().Activation();
        }

        if (Left != null)
        {
            Left.GetComponent<Puzzle_3x3>().Activation();
        }

        if (Right != null)
        {
            Right.GetComponent<Puzzle_3x3>().Activation();
        }
    }


    //Enters trigger, sets IsOnTop to true to allow Keydown
    private void OnTriggerEnter2D(Collider2D col)
    {
        IsOnTop = true;
    }

    //Exits trigger, sets IsOnTop to false to prevent Keydown
    private void OnTriggerExit2D(Collider2D col)
    {
        IsOnTop = false;
    }
}
