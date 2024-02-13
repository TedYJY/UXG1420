using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_WindPlate_PlateTimer : MonoBehaviour
{
    public GameObject Torch;

    private GameObject TorchCollider;


    // Start is called before the first frame update
    void Start()
    {
        TorchCollider = GameObject.Find("Torch_Collider");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "BigPlayer")
        {
            TorchCollider.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "BigPlayer" && Torch.GetComponent<Puzzle_WindPlate_Torch>().IsActivatedCheck() == false)
        {
            TorchCollider.SetActive(true);
        }
    }
}
