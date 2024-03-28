using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle3x1Torch : MonoBehaviour
{

    [SerializeField] private bool isAble;
    [SerializeField] private bool isActivated;
    [SerializeField] private GameObject ObjectiveHandler;

    private static int tracker = 0;

    [Header("Sprite Allocation")]
    [SerializeField] private GameObject TorchFire;
    //[SerializeField] private Sprite activatedTorch;
    //[SerializeField] private Sprite deactivatedTorch;
    //[SerializeField] private Sprite finishedTorch;

    [SerializeField] private GameObject lPressure;
    [SerializeField] private GameObject rPressure;

    public GameObject Bridge_Collider;
    public GameObject Bridge_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")  && isAble == true)
        {
            isActivated = !isActivated;
            Activate();
        }

        if (tracker == 3)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;

            lPressure.GetComponent<puzzle3x1>().enabled = false;
            rPressure.GetComponent<puzzle3x1>().enabled = false;
            this.GetComponent<puzzle3x1Torch>().enabled = false;

            try
            {
                ObjectiveHandler.GetComponent<Lvl1_ObjectiveHandler>().ManualChangeObjective();
                Bridge_Collider.SetActive(false);
                Bridge_Sprite.SetActive(true);
                
            }
            catch
            {
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ghost")
        {
            isAble = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ghost")
        {
            isAble = false;
        }
    }

    private void Activate()
    {

        if (isActivated)
        {
            ++tracker;
            //this.GetComponent<SpriteRenderer>().sprite = activatedTorch;
            TorchFire.GetComponent<Torch_Fire_Activation>().StartFire();
        }

        else
        {
            --tracker;
            //this.GetComponent<SpriteRenderer>().sprite = deactivatedTorch;
            TorchFire.GetComponent<Torch_Fire_Activation>().StopFire();
        }

    }

    public bool CheckActivated()
    {
        return isActivated;
    }

    public void SwapActivated(bool newBool)
    {
        isActivated = newBool;
        Activate();
    }

    public void Solved ()
    {

    }
}
