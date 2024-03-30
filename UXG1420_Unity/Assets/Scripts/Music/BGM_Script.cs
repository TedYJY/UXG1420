using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Script : MonoBehaviour
{
    public AudioSource BGM_Player;
    public AudioClip BGM_Front;

    // Start is called before the first frame update
    void Start()
    {
        BGM_Player.PlayOneShot(BGM_Front);
        BGM_Player.PlayScheduled(AudioSettings.dspTime + BGM_Front.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
