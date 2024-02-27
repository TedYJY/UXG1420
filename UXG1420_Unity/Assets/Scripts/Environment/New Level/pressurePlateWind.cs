using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateWind : MonoBehaviour
{
    public GameObject WindToTrigger;
    public GameObject WindSprite;
    public GameObject ExtraPressurePlate = null;
    public bool IsActivated;
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
            IsActivated = true;
            CheckRequirement();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Pressed;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if ((coll.tag == "Rock" || coll.tag == "BigPlayer") && ItemsOnPlate == 1)
        {

            ItemsOnPlate--;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Unpressed;
            IsActivated = false;
            CheckRequirement();
            try
            {
                DeActivateWind();
            }

            catch
            {

            }

         
        }
        
        else if (coll.tag == "Rock" || coll.tag == "BigPlayer")
        {
            ItemsOnPlate--;
        }
        
    }

    private void CheckRequirement()
    {
        if (ExtraPressurePlate == null && IsActivated == true)
        {
            /*DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
            BridgeSprites.SetActive(false);*/
            ActivateWind();
        }

        else if (ExtraPressurePlate != null && ExtraPressurePlate.GetComponent<puzzleBridge>().IsActivated && IsActivated == true)
        {
            //DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            //DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
            //BridgeSprites.SetActive(false);
            ActivateWind();
        }

        else
        {
            try
            {
                WindToTrigger.GetComponent<BoxCollider2D>().enabled = true;
                WindToTrigger.GetComponent<SpriteRenderer>().color = Color.red;
            }

            catch
            {
                //Debug.Log("Not enough for bridge!");
            }
        }
    }

    private void ActivateWind()
    {
        WindToTrigger.GetComponent<BoxCollider2D>().enabled = true;
        WindSprite.SetActive(true);
        //BridgeSprites.SetActive(true);
    }

    private void DeActivateWind()
    {
        WindToTrigger.GetComponent<BoxCollider2D>().enabled = false;
        WindSprite.SetActive(false);
    }
}
