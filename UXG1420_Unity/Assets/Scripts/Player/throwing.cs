using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwing : MonoBehaviour
{

    public bool isThrowable = false;
    public GameObject smallPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            AttemptThrow();
        }
    }

    private void AttemptThrow()
    {
        if (isThrowable == true)
        {
            smallPlayer.transform.SetParent(this.transform);
            smallPlayer.transform.position = transform.position;
        }

    }


}
