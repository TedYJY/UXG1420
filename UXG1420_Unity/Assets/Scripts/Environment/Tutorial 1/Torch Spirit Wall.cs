using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TorchSpiritWall : MonoBehaviour
{

    public Sprite TorchLit;
    public Sprite TorchUnLit;
    public GameObject TorchCollider;
    

    [SerializeField]
    private bool IsAble;
    private bool IsActivated = false;

    public GameObject BridgeCollider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsAble == true)
        {
            if (IsActivatedCheck() == false)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = TorchLit;
                DeactivateBarrier();
                IsActivated = true;
                

                try
                {
                }

                catch { }
            }
            else 
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = TorchUnLit;
                ActivateBarrier();
                IsActivated = false;

                try
                {
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

    public void DeactivateBarrier()
    {
        TorchCollider.SetActive(false);
        
    }

    public void ActivateBarrier()
    {
        TorchCollider.SetActive(true);
        
    }

    public bool IsActivatedCheck()
    {
        
        Debug.Log(IsActivated);
        return IsActivated;
    }
}
