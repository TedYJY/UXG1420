using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleWindplatePlateTimer : MonoBehaviour
{
    public GameObject Torch;
    public GameObject TorchCollider;

    public Sprite Unpressed;
    public Sprite Pressed;

    private bool Is_Pressed = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "BigPlayer" && Torch.GetComponent<puzzleWindplateTorch>().IsActivatedCheck() == false && Is_Pressed == false)
        {
            try
            {
                Is_Pressed = true;
                TorchCollider.GetComponent<Spirit_Barrier_Active_Script>().TriggerBarrier();
                this.GetComponent<SpriteRenderer>().sprite = Pressed;
                Debug.Log("Press_Triggered");
            }
            catch
            {
                Debug.Log("Press_Trigger_Fail");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BigPlayer" && Torch.GetComponent<puzzleWindplateTorch>().IsActivatedCheck() == false && Is_Pressed == true)
        {
            try
            {
                Is_Pressed = false;
                TorchCollider.GetComponent<Spirit_Barrier_Active_Script>().TriggerBarrier();
                this.GetComponent<SpriteRenderer>().sprite = Unpressed;
                Debug.Log("Unpress_Triggered");
            }

            catch
            {
                Debug.Log("Unpress_Trigger_Fail");
            }

        }
    }
}
