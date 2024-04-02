using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCanvas_Sound_Scirpt : MonoBehaviour
{
    [SerializeField]
    private AudioSource Bush_Audio_Source;
    // Start is called before the first frame update
    void Start()
    {
        Bush_Audio_Source = GameObject.FindWithTag("Bush_Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRustle()
    {
        Bush_Audio_Source.Play();
    }
}
