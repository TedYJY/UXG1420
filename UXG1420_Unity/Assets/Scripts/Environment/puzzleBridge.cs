using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class puzzleBridge : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DrawbridgeTrigger;
    public GameObject BridgeSprites;
    public GameObject ExtraPressurePlate = null;
    public bool IsActivated;
    public bool BridgeIsActivated = false;
    public int ItemsOnPlate;

    public Sprite Unpressed;
    public Sprite Pressed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
            if (coll.tag == "Rock" || coll.tag == "BigPlayer")
            {
                ItemsOnPlate++;
                //Debug.Log(this.ItemsOnPlate);
                IsActivated = true;
                CheckRequirement();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Pressed;
                //this.gameObject.GetComponent<PressurePlate_Sound_Script>().PlayPush();

            }
    }


    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Rock" || coll.tag == "BigPlayer")
        {
            if (ItemsOnPlate > 1)
            {
                ItemsOnPlate--;
            }

            else if (ItemsOnPlate == 1)
            {
                ItemsOnPlate--;
                IsActivated = false;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Unpressed;
                this.gameObject.GetComponent<PressurePlate_Sound_Script>().PlayRelease();
                
                
                //Debug.Log(this.ItemsOnPlate);
                CheckRequirement();
                try
                {
                    BridgeSprites.SetActive(false);
                }

                catch
                {

                }
            }
            
        }
    }

    private void CheckRequirement()
    {
        if (ExtraPressurePlate == null && IsActivated == true)
        {
            /*DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
            BridgeSprites.SetActive(false);*/

            ActivateBridge();
        }

        else if (ExtraPressurePlate != null && ExtraPressurePlate.GetComponent<puzzleBridge>().IsActivated && IsActivated == true)
        {
            //DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            //DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
            //BridgeSprites.SetActive(false);
            ActivateBridge();
        }

        else
        {
            try
            {
                DeactivateBridge();
            }

            catch
            {
                //Debug.Log("Not enough for bridge!");
            }
        }
    }

    private void ActivateBridge()
    {
        if (BridgeIsActivated == false)
        {
            DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            try
            {
                Debug.Log("Activating Bridge");
                this.gameObject.GetComponent<PressurePlate_Sound_Script>().PlayPush();
                DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
            }
            catch
            {

            }
            BridgeSprites.SetActive(true);

            BridgeIsActivated = true;
        }

    }

    private void DeactivateBridge()
    {
        if (BridgeIsActivated == true)
        {
            DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = true;
            try
            {
                DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.red;
            }
            catch
            {

            }
            BridgeSprites.SetActive(false);

            BridgeIsActivated = false;
        }

    }


}
