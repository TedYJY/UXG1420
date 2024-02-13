using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Puzzle_WindPlate_Torch : MonoBehaviour
{
    private GameObject TorchCollider;
    private GameObject SpiritBridge;
    private bool IsAble;

    // Start is called before the first frame update
    void Start()
    {
        TorchCollider = GameObject.Find("Torch_Collider");
        SpiritBridge = GameObject.Find("Bridge_East");
        IsAble = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsAble == true)
        {
            SpiritBridge.GetComponent<BoxCollider2D>().enabled = false;
            SpiritBridge.GetComponent<SpriteRenderer>().color = Color.green;
            TorchCollider.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        IsAble = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        IsAble = false;
    }
}