using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStoryScript : MonoBehaviour
{
    public GameObject levelLoader;
    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutSceneStart());
        //Debug.Log("Started");
    }

    IEnumerator CutSceneStart()
    {
        yield return new WaitForSeconds(transitionTime);
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
    }

}
