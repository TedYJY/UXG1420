using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "BigPlayer")
        {
            //Upon entering trigger zone, destroys if it is Beary
            Destroy(col.gameObject);
        }
    }
}
