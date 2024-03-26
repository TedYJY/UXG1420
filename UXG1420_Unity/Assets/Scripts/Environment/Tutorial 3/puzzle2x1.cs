using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class puzzle2x1 : MonoBehaviour
{
    [Header("Torch Allocation")]
    [SerializeField] private GameObject topTorch;
    [SerializeField] private GameObject bottomTorch;
    //[SerializeField] private GameObject middleTorch;

    public Sprite Unpressed;
    public Sprite Pressed;

    //[SerializeField] private bool isLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwapStates()
    {
        if (topTorch.GetComponent<puzzle2x1Torch>().CheckActivated() != bottomTorch.GetComponent<puzzle2x1Torch>().CheckActivated())
        {
            bool temp = topTorch.GetComponent<puzzle2x1Torch>().CheckActivated();
            topTorch.GetComponent<puzzle2x1Torch>().SwapActivated(bottomTorch.GetComponent<puzzle2x1Torch>().CheckActivated());
            bottomTorch.GetComponent<puzzle2x1Torch>().SwapActivated(temp);
        }

        /*else if (middleTorch.GetComponent<puzzle2x1Torch>().CheckActivated() != bottomTorch.GetComponent<puzzle2x1Torch>().CheckActivated())
        {
            bool temp = middleTorch.GetComponent<puzzle2x1Torch>().CheckActivated();
            middleTorch.GetComponent<puzzle2x1Torch>().SwapActivated(bottomTorch.GetComponent<puzzle2x1Torch>().CheckActivated());
            bottomTorch.GetComponent<puzzle2x1Torch>().SwapActivated(temp);

        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigPlayer")
        {
            SwapStates();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Pressed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BigPlayer")
        {
            SwapStates();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Unpressed;
        }
    }

}
