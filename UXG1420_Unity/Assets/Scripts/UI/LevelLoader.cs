using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    [SerializeField]
    private Animator DialogueAnim;
    public float transitionTime = 1f;
    // Update is called once per frame

    [SerializeField] //
    private GameObject dialogueUI; //

    void Start()
    {
        Invoke("balls", 3);
    }


    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))//Input.GetMouseButtonDown(0)
        {
            LoadNextLevel();
        } //*/
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



    void balls()
    {
        //dialogueUI.SetActive(true); 
        DialogueAnim.Play("DialogueBox");
        //need to have animator, set initial alpha to 0, then to 100
        Debug.Log("ballsballsballs");
        //
    }

}
