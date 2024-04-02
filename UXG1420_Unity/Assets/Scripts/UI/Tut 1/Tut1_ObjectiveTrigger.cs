using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut1_ObjectiveTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectiveHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BigPlayer")
        {
            ObjectiveHandler.GetComponent<Tut1_ObjectiveHandler>().ManualChangeObjective();
            this.gameObject.SetActive(false);
        }
    }
}
