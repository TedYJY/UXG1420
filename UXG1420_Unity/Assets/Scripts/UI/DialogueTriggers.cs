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


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Ghost" && dialogueTracker==true)
        {
            Debug.Log("no more CONVO");
            dialogueTracker = false;
            GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>().DialogueBoxFadeInAnim();
            
            //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }


    }

}
