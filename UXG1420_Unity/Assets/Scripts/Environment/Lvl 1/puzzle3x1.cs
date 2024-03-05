using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class puzzle3x1 : MonoBehaviour
{
    [Header("Torch Allocation")]
    [SerializeField] private GameObject leftTorch;
    [SerializeField] private GameObject rightTorch;
    [SerializeField] private GameObject middleTorch;

    public Sprite Unpressed;
    public Sprite Pressed;

    [SerializeField] private bool isLeft;

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
        if (isLeft && (leftTorch.GetComponent<puzzle3x1Torch>().CheckActivated() != middleTorch.GetComponent<puzzle3x1Torch>().CheckActivated()))
        {
            bool temp = leftTorch.GetComponent<puzzle3x1Torch>().CheckActivated();
            leftTorch.GetComponent<puzzle3x1Torch>().SwapActivated(middleTorch.GetComponent<puzzle3x1Torch>().CheckActivated());
            middleTorch.GetComponent<puzzle3x1Torch>().SwapActivated(temp);
        }

        else if (isLeft == false && (middleTorch.GetComponent<puzzle3x1Torch>().CheckActivated() != rightTorch.GetComponent<puzzle3x1Torch>().CheckActivated()))
        {
            bool temp = middleTorch.GetComponent<puzzle3x1Torch>().CheckActivated();
            middleTorch.GetComponent<puzzle3x1Torch>().SwapActivated(rightTorch.GetComponent<puzzle3x1Torch>().CheckActivated());
            rightTorch.GetComponent<puzzle3x1Torch>().SwapActivated(temp);

        }
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
