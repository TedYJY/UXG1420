using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class puzzleWindplateTorch : MonoBehaviour
{

    public GameObject BridgeSprites;
    public Sprite TorchLit;
    public GameObject TorchFire;

    [SerializeField]
    private GameObject ObjectiveHandler;

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
        if (Input.GetKeyDown(KeyCode.E) && IsAble == true && IsActivated == false)
        {
            BridgeSprites.SetActive(true);
            BridgeCollider.SetActive(false);
            TorchCollider.GetComponent<Spirit_Barrier_Active_Script>().TriggerOnlyDeactivate();
            IsActivated = true;
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = TorchLit;
            TorchFire.GetComponent<Torch_Fire_Activation>().StartFire();

            TorchCollider.SetActive(false);

            try
            {
                ObjectiveHandler.GetComponent<Lvl2_ObjectiveHandler>().ManualChangeObjective();
            }

            catch { }

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
