using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 vmovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vmovement.x = Input.GetAxisRaw("Horizontal");
        vmovement.y = Input.GetAxisRaw("Vertical");
        vmovement = vmovement.normalized;

    }

    void FixedUpdate()
    {   
        rb.MovePosition(rb.position + vmovement * moveSpeed * Time.fixedDeltaTime);
    }
}
