using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] //pairs along with private objects
    private Animator DialogueAnimDisappear; //to drag the dialogueAnimation in the inspector

    [SerializeField]
    private GameObject LvlLoader; // drag manager into levelloader inspector


    public Dialogue dialogue; //needed for dialogue code to run

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DialogueBoxFadeInAnim", 3);
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
            //Debug.Log("dialogue continue");
        }
        DisplayNextSentence();

        /*if (sentences.Count!=0)
        {
            Debug.Log("fuck");
        }//*/
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            Debug.Log("dialoguedialogue");
            return;
        }
        /*if (sentences.Count!=0)
        {
            Debug.Log("dialoguedialogue");
        }//*/
        //testing purpose
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines(); // to prevent user from starting a new sentence before the current has finished animating
        StartCoroutine(TypeSentence(sentence)); //start coroutine, then pass in the sentence to type
    }


    IEnumerator TypeSentence(string sentence) //animation for letters
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
        LvlLoader.GetComponent<LevelLoader>().DialogueBoxFadeOutAnim();       
    }


}
