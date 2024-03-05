using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windTurbineLeft : MonoBehaviour
{
    public float distance = 10f;
    public float rightforce = 1500f;
    public float upforce = 500f;

    public Transform castPoint;
    public bool IsActive;

    public Sprite Activated_Head;
    public Sprite Deactivated_Head;

    public LayerMask hitLayers;

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
        Vector2 endPos = castPoint.position + Vector3.left * distance;

        //Creates Raycast
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, hitLayers);
        

        if (hit.collider != null && IsActive == true)
        {
            
            if (hit.collider.gameObject.CompareTag("Rock"))
            {
                hit = Physics2D.Linecast(castPoint.position, hit.point, hitLayers);
                Debug.DrawLine(castPoint.position, hit.point, Color.blue);
            }

            else if (hit.collider.gameObject.CompareTag("BigPlayer"))
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * rightforce);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upforce);
                Debug.DrawLine(castPoint.position, hit.point, Color.red);
                //Debug.Log("blowing his ass");
            }

            //Debug.Log("Is stuck");

        }
        
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.white);
        }
    }

    public void ActivateHead()
    {
        this.GetComponent<SpriteRenderer>().sprite = Activated_Head;
        IsActive = true;
    }

    public void DeactivateHead()
    {
        this.GetComponent<SpriteRenderer>().sprite = Deactivated_Head;
        IsActive = false;
    }
}
