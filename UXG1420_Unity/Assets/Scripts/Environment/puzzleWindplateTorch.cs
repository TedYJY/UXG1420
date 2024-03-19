using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class puzzleWindplateTorch : MonoBehaviour
{

    public GameObject BridgeSprites;
    public Sprite TorchLit;

    [SerializeField]
    private GameObject BridgeCollider;

    [SerializeField]
    private GameObject TorchCollider;
    private bool IsAble;
    private bool IsActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        IsAble = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsAble == true)
        {
            BridgeSprites.SetActive(true);
            BridgeCollider.SetActive(false);
            TorchCollider.SetActive(false);
            IsActivated = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = TorchLit;

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

    public bool IsActivatedCheck()
    {
        return IsActivated;
    }
}
