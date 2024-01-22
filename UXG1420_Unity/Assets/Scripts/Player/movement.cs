using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 vmovement;

    private PickUp pickUp; 

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            pickUp = gameObject.GetComponent<PickUp>();
            pickUp.Direction = new Vector2(0, -1);

        }

        catch
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        vmovement.x = Input.GetAxisRaw("Horizontal");
        vmovement.y = Input.GetAxisRaw("Vertical");
        vmovement = vmovement.normalized;

        if (vmovement.sqrMagnitude > .1f && pickUp != null)
        {
            pickUp.Direction = vmovement.normalized;
        }

    }

    void FixedUpdate()
    {   
        rb.MovePosition(rb.position + vmovement * moveSpeed * Time.fixedDeltaTime);
    }
}
