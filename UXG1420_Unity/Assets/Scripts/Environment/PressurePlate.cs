using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{

    public GameObject triggerableObject;
    public GameObject disableableDoor;
    public SpriteRenderer spriteRen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject == triggerableObject)
        {
            disableableDoor.SetActive (false);
            spriteRen.color = Color.green;
        }
    }

    public void OnTriggerExit2D (Collider2D coll)
    {
        if (coll.gameObject == triggerableObject)
        {
            disableableDoor.SetActive (true);
            spriteRen.color = Color.white;
        }
    }
}
