using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIndBlocking : MonoBehaviour
{
    public GameObject WindSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Rock") == true)
        {
            WindSprite.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Rock") == true)
        {
            WindSprite.SetActive(true);
        }
    }
}
