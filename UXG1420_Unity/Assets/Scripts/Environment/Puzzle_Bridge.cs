using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puzzle_Bridge : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject DrawbridgeTrigger;
    public GameObject ExtraPressurePlate = null;
    public bool IsActivated;

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
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            IsActivated = true;
            CheckRequirement();

        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Rock")
        {

            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            IsActivated = false;
            CheckRequirement();
        }
    }

    private void CheckRequirement()
    {
        if (ExtraPressurePlate == null && IsActivated == true)
        {
            DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
        }

        else if (ExtraPressurePlate != null && ExtraPressurePlate.GetComponent<Puzzle_Bridge>().IsActivated && IsActivated == true)
        {
            DrawbridgeTrigger.GetComponent<BoxCollider2D>().enabled = false;
            DrawbridgeTrigger.GetComponent<SpriteRenderer>().color = Color.green;
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
}
