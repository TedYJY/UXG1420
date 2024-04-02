using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishingPointScript : MonoBehaviour
{
    public LevelLoader LevelLoader;

    private AudioSource Completion_Audio;

    // Start is called before the first frame update
    void Start()
    {
        Completion_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigPlayer")
        {
            LevelLoader.LoadNextLevel();
            Completion_Audio.Play();
        }
    }
}
