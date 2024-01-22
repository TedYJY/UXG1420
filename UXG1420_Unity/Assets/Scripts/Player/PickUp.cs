using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 Direction { get; set; }
    public GameObject itemHolding;
    public float ThrowSpeed = 0.01f;
    public int ForSpeed = 100;
    public int ThrowDistance = 5;
    public GameObject throwMarker;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;

            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemHolding)
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }

        if (itemHolding)
        {
            throwMarker.transform.position = transform.position + Direction * ThrowDistance;

        }   
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * ThrowDistance;
        item.transform.parent = null;
        for (int i = 0; i < ForSpeed; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * ThrowSpeed);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
    }

}
