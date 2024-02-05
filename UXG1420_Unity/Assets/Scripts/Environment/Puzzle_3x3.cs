using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_3x3 : MonoBehaviour
{

    public GameObject Top;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;
    public bool IsActivated = false;
    public bool IsOnTop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsOnTop == true)
        {
            Activation();
            ActivationSurrounding();
        }
    }

    private void Activation()
    {
        if (!IsActivated)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            IsActivated = true;
        }

        else if (IsActivated)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            IsActivated = false;
        }

    }

    private void ActivationSurrounding()
    {
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        IsOnTop = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        IsOnTop = false;
    }
}
