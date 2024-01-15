using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSwapping : MonoBehaviour
{
    public GameObject playerref;
    public GameObject cameraref;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwapCharacter();
        }
    }

    void SwapCharacter()
    {
        GetComponent<Movement>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        playerref.GetComponent<Movement>().enabled = true;
        playerref.GetComponent<Collider2D>().enabled = true;
        playerref.GetComponent<characterSwapping>().enabled = true;

        cameraref.GetComponent<cameraTracking>().target = playerref.transform;
    }
}