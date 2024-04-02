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
                Debug.Log("Press_Triggered");
                Is_Pressed = true;
                //if (TorchCollider.GetComponent<Animator>().GetBool("Is_Animating"))
                TorchCollider.GetComponent<Spirit_Barrier_Active_Script>().TriggerOnlyDeactivate();
                this.GetComponent<SpriteRenderer>().sprite = Pressed;
                this.GetComponent<PressurePlate_Sound_Script>().PlayPush();
                
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
                Debug.Log("Unpress_Triggered");
                Is_Pressed = false;
                TorchCollider.GetComponent<Spirit_Barrier_Active_Script>().TriggerOnlyActivate();
                this.GetComponent<SpriteRenderer>().sprite = Unpressed;
                this.GetComponent<PressurePlate_Sound_Script>().PlayRelease();
                
            }

            catch
            {
                Debug.Log("Unpress_Trigger_Fail");
            }

        }
    }
}
