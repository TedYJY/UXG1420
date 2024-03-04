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
        /*if (Input.GetMouseButtonDown(0))//Input.GetMouseButtonDown(0)
        {
            LoadNextLevel();
        } 

        if (Input.GetKeyDown("e"))
        {
            Invoke("DialogueBoxFadeInAnim", 3);
        }//*/

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

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Detect collision for pushing animation
        if (collision.gameObject.tag == "BigPlayer")
        {
            //animator.SetBool("Pushing", true);
            Invoke("DialogueBoxFadeInAnim", 2);
            Debug.Log("collide with torch");
        }
    }//*/



    public void DialogueBoxFadeInAnim()
    {
        //dialogueUI.SetActive(true); 
        DialogueAnim.Play("DialogueBox");
        //need to have animator, set initial alpha to 0, then to 100
        //moved dialogue trigger script code to here so that it will start along with level loader
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }

    public void DialogueBoxFadeOutAnim()
    {
        DialogueAnim.Play("DialogueBoxFadeOut");
    }

}
