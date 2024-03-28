using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Fire_Activation : MonoBehaviour
{
    public bool Is_Active;
    // Start is called before the first frame update
    void Start()
    {
        if (Is_Active == true)
        {
            this.StartFire();
        }
        else
        {
            this.StopFire();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopFire()
    {
        Debug.Log("Stopping Fire");
        this.GetComponentInChildren<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void StartFire()
    {
        Debug.Log("Starting Fire");
        this.GetComponentInChildren<ParticleSystem>().Play(true);
    }
}
