using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstBridgeDialogueTrigger : MonoBehaviour
{


    public Dialogue dialogue;

    public bool dialogueTracker = true;

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    public void OnTriggerStay2D(Collider2D collision) //to enable convo with torch
    {


        if ((collision.gameObject.tag == "BigPlayer" || collision.gameObject.tag == "Rock") && dialogueTracker == true && GetComponentInParent<SpriteRenderer>().sprite == GetComponentInParent<puzzleBridge>().Pressed)
        {
            //stops triggering dialogue box after colliding once with torch
            Debug.Log("stops triggering dialogue box after colliding once with torch");
            dialogueTracker = false;
            GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>().DialogueBoxFadeInAnim();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }

    /*
        public void OnCollisionEnter2D(Collision2D collision)
    {
        //Detect collision for pushing animation
        if (collision.gameObject.tag == "Rock" && movement.sqrMagnitude > 0.01)
        {
            animator.SetBool("Pushing", true);
        }

    }
    //*/

}
