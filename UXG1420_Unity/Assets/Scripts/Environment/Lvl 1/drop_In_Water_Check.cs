using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_In_Water_Check : MonoBehaviour
{
    private BoxCollider2D collider;
    private PauseMenu pauseMenu;
    private BoxCollider2D parentBridgeCollider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        pauseMenu = GameObject.FindWithTag("Pause").GetComponent<PauseMenu>();
        parentBridgeCollider = this.transform.parent.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Rock" && parentBridgeCollider.isActiveAndEnabled == true)
        {
            pauseMenu.RestartGameWithoutPause();
        }
    }
}
