using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class outline : MonoBehaviour
{
    private Beary_Glow_Script Glow;

    private SpriteRenderer outlineColor;

    private bool Is_colliding;

    [SerializeField]
    private GameObject currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        outlineColor = this.gameObject.GetComponent<SpriteRenderer>();
        Glow = this.GetComponentInParent<Beary_Glow_Script>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ghost")
        {
            //Outlines the nearby player
            //outlineColor.color = UnityEngine.Color.cyan;

            //Activate Glow
            Glow.TriggerOnlyActivate();

            //Tags the current player and changes condition of "swapping" script to enable possessing
            currentPlayer = col.gameObject;
            currentPlayer.GetComponent<playerHandler>().outlineNearby(this.gameObject, true);

            Is_colliding = true;
        }

        /*if (col.tag == "BigPlayer")
        {
            outlineColor.color = Color.green;
            col.gameObject.GetComponent<throwing>().isThrowable = true;
        }*/
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ghost")
        {
            currentPlayer.GetComponent<playerHandler>().outlineNearby(null, false);
            Glow.TriggerOnlyDeactivate();


            try
            {
                GameObject.FindWithTag("UI").GetComponent<UIScripts>().TurnEInactive();
            }

            catch
            {

            }
        }

        //outlineColor.color = UnityEngine.Color.white;
        
    }
}
