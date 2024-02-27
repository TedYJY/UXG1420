using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windTurbine : MonoBehaviour
{
    public float distance = 10f;
    public float rightforce = 1500f;
    public float upforce = 500f;

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
                hit = Physics2D.Linecast(castPoint.position, hit.point);
                Debug.DrawLine(castPoint.position, hit.point, Color.blue);
            }

            else if (hit.collider.gameObject.CompareTag("BigPlayer"))
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightforce);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upforce);
                Debug.DrawLine(castPoint.position, hit.point, Color.red);
            }


        }
        
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.white);
        }
    }
}
