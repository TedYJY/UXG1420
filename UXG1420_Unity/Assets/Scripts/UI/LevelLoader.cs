using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
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

}
