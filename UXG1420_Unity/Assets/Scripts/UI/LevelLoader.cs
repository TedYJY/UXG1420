using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Dialogue dialogue; //needed for dialogue code to run

    public Animator transition;

    [SerializeField] //pairs along with private objects
    private Animator DialogueAnim; //to drag the dialogueAnimation in the inspector


    public float transitionTime = 1f;
    // Update is called once per frame

    [SerializeField] //pairs along with private objects
    private GameObject dialogueUI; //to drag dialogueSystem in the inspector

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex==4)
        {
            //NewDialogueBoxAnim();
        }
        else
        {
            Invoke("NewDialogueBoxAnim", 3);
        }//*/
        //Invoke("DialogueBoxFadeInAnim", 3);
    }


    /*public void AutoCallDialogue()
    {
        Invoke("DialogueBoxFadeInAnim", 3);
    }*/

    void Update()
    {


    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
        
    }





    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


    public void DialogueBoxFadeInAnim(Dialogue FadeInDialogue) //this method will trigger a dialogue box based on something that you drop in the inspector
    {

        try
        {

            Debug.Log("fade in dialogue box");
            //dialogueUI.SetActive(true); 
            DialogueAnim.Play("DialogueBox");
            //need to have animator, set initial alpha to 0, then to 100
            //moved dialogue trigger script code to here so that it will start along with level loader
            FindObjectOfType<DialogueManager>().StartDialogue(FadeInDialogue);
        }
        catch
        {
            
        }
        
        
    }

    public void NewDialogueBoxAnim() //this method will trigger a dialogue box based on serialized field
    {
        try
        {

            Debug.Log("fade in dialogue box");
            DialogueAnim.Play("DialogueBox");
            //need to have animator, set initial alpha to 0, then to 100
            //moved dialogue trigger script code to here so that it will start along with level loader
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        catch
        {
            
        }
    }


    public void DialogueBoxFadeOutAnim()
    {
        DialogueAnim.Play("DialogueBoxFadeOut");
    }

}
