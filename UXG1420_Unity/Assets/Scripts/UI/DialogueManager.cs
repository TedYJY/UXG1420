using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting Convo" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        //testing purpose
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines(); // to prevent user from starting a new sentence before the current has finished animating
        StartCoroutine(TypeSentence(sentence)); //start coroutine, then pass in the sentence to type
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letters in sentence.ToCharArray()) //converts a string into a character array
        {
            dialogueText.text+= letters;
            yield return new WaitForSeconds(0.05f); //wait 1 second for letters
            //yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("end of convo");
    }


}
