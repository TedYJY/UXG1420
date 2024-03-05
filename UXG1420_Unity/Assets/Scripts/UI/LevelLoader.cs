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
        Invoke("DialogueBoxFadeInAnim", 3);
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


    public void DialogueBoxFadeInAnim()
    {

        try
        {
            //dialogueUI.SetActive(true); 
            DialogueAnim.Play("DialogueBox");
            //need to have animator, set initial alpha to 0, then to 100
            //moved dialogue trigger script code to here so that it will start along with level loader
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        catch
        {

        }
        
        
    }


    /*
    
    void VFXControl()
    {
        try
        {
            // your code segment which might throw an exception
        }
        catch (Exception ex)
        {
            Debug.LogException(ex, this);
        }
    }
    //*/


    public void DialogueBoxFadeOutAnim()
    {
        DialogueAnim.Play("DialogueBoxFadeOut");
    }

}
