using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{

    [SerializeField] //pairs along with private objects
    private GameObject WASDActivator;

    public Dialogue dialogue;

    public bool dialogueTracker = true;

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    public void OnTriggerEnter2D(Collider2D collision) //to enable convo with torch
    {
        if (collision.gameObject.tag=="Ghost" && dialogueTracker==true)
        {
            //stops triggering dialogue box after colliding once with torch
            Debug.Log("stops triggering dialogue box after colliding once with torch");
            dialogueTracker = false;
            GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>().DialogueBoxFadeInAnim();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

            //WASDActivator = GameObject.FindWithTag("UI");
            //WASDActivator.GetComponent<UIScripts>().enabled = true;
        }


        if (collision.gameObject.tag == "BigPlayer" && dialogueTracker == true)
        {
            //stops triggering dialogue box after colliding once with torch
            Debug.Log("stops triggering dialogue box after colliding once with torch");
            dialogueTracker = false;
            GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>().DialogueBoxFadeInAnim();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }

}
