using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private AudioSource audioSource;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip newAudio)
    {
        audioSource.clip = newAudio;
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }


}
