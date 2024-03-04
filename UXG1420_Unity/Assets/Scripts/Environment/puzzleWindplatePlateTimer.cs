using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleWindplatePlateTimer : MonoBehaviour
{
    public GameObject Torch;
    public GameObject TorchCollider;

    public Sprite Unpressed;
    public Sprite Pressed;


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
        if (coll.tag == "BigPlayer")
        {
            try
            {
                TorchCollider.SetActive(false);
                this.GetComponent<SpriteRenderer>().sprite = Pressed;
            }
            catch
            {

            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BigPlayer" && Torch.GetComponent<puzzleWindplateTorch>().IsActivatedCheck() == false)
        {
            try
            {
                TorchCollider.SetActive(true);
                this.GetComponent<SpriteRenderer>().sprite = Unpressed;
            }

            catch
            {

            }

        }
    }
}
