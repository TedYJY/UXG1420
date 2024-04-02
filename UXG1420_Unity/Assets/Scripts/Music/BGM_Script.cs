using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Script : MonoBehaviour
{
    public AudioSource BGM_Player;
    public AudioClip BGM_Front;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.transform.GetChild(0).gameObject);
 
        BGM_Player.PlayOneShot(BGM_Front);
        Debug.Log("playingfront");
        BGM_Player.PlayScheduled(AudioSettings.dspTime + BGM_Front.length);
        Debug.Log("playingLoop");

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
