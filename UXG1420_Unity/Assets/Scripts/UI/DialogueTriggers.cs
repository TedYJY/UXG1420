using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{


    //THIS SCRIPT IS OBSOLETE

    public Dialogue dialogue;

    public bool dialogueTracker = true;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    public void OnTriggerEnter2D(Collider2D collision) //to enable convo with torch
    {
        if (collision.gameObject.tag=="Ghost" && dialogueTracker==true)
        {
            Debug.Log("no more CONVO");
            dialogueTracker = false;
            GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>().DialogueBoxFadeInAnim();
            //GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>().DialogueBoxFadeInAnimTEST();

            //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        /*if (GameObject.FindWithTag("DialogueManager").GetComponent<DialogueManager>().sentences.count==)
        {

        }//*/

    }

}
