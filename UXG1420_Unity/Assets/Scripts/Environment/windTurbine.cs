using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windTurbine : MonoBehaviour
{
    public float distance = 10f;

    public Transform castPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector2 endPos = castPoint.position + Vector3.right * distance;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Rock"))
            {
                Debug.Log("Rock hit by RC");
                hit = Physics2D.Linecast(castPoint.position, hit.point);
                Debug.DrawLine(castPoint.position, hit.point, Color.blue);
            }



        }
        
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.white);
        }
    }
}
