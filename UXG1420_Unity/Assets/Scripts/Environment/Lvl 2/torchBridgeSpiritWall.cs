using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TorchBridgeSpiritWall : MonoBehaviour
{

    public GameObject BridgeSprites;
    public Sprite TorchLit;
    public Sprite TorchUnLit;
    public GameObject TorchCollider;
    

    private GameObject BridgeCollision;
    [SerializeField]
    private bool IsAble;
    private bool IsActivated = false;

    public GameObject BridgeCollider;

    // Start is called before the first frame update
    void Start()
    {
        BridgeCollision = GameObject.Find("Bridge_Collidor");
        IsAble = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsAble == true)
        {
            if (IsActivatedCheck() == false)
            {
                
                //BridgeCollision.GetComponent<BoxCollider2D>().enabled = false;
                
                BridgeCollision.GetComponent<SpriteRenderer>().color = Color.green;
                BridgeSprites.SetActive(true);
                TorchCollider.SetActive(true);
                IsActivated = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = TorchLit;

                try
                {
                    BridgeCollider.SetActive(false);
                }

                catch { }
            }
            else 
            {
                
               // BridgeCollision.GetComponent<BoxCollider2D>().enabled = true;
                
                BridgeCollision.GetComponent<SpriteRenderer>().color = Color.red;
                BridgeSprites.SetActive(false);
                TorchCollider.SetActive(false);
                IsActivated = false;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = TorchUnLit;

                try
                {
                    BridgeCollider.SetActive(true);
                }

                catch { }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Ghost") 
        {
            IsAble = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Ghost")
        {
            IsAble = false;
        }
    }

    public bool IsActivatedCheck()
    {
        
        Debug.Log(IsActivated);
        return IsActivated;
    }
}
