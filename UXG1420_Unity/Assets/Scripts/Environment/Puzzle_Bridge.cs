using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puzzle_Bridge : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject DrawbridgeTrigger;
    public GameObject BridgeSprites;
    public GameObject ExtraPressurePlate = null;
    public bool IsActivated;

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
        if (coll.tag == "Rock")
        {
            IsActivated = true;
            CheckRequirement();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Pressed;
            
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Rock")
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = Unpressed;
            IsActivated = false;
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

    private void CheckRequirement()
    {
        if (ExtraPressurePlate == null && IsActivated == true)
        {
            /*DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
            BridgeSprites.SetActive(false);*/
            ActivateBridge();
        }

        else if (ExtraPressurePlate != null && ExtraPressurePlate.GetComponent<Puzzle_Bridge>().IsActivated && IsActivated == true)
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
                DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = true;
                DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.red;
            }

            catch
            {
                Debug.Log("Not enough for bridge!");
            }
        }
    }

    private void ActivateBridge()
    {
        DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
        DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
        BridgeSprites.SetActive(true);
    }
}
