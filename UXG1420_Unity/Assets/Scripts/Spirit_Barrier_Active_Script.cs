using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit_Barrier_Active_Script : MonoBehaviour
{
    [SerializeField] 
    private Animator animator = null;

    public bool IsActive;

    //private bool IsAnimating = false;

    private static readonly int Is_On_Hash = Animator.StringToHash("Is_On");
    private static readonly int Is_Animating_Hash = Animator.StringToHash("Is_Animating");

    private EdgeCollider2D this_Collider;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, IsActive);
        this_Collider = this.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerBarrier()
    {
        
        
        animator.SetTrigger("Fade");
        this_Collider.enabled = !this_Collider.enabled;
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, true);


    }

    public void TriggerOnlyActivate()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, false);
        Debug.Log("Is on to false");
        animator.SetTrigger("Fade");
        Debug.Log("Start anim");
        this_Collider.enabled = true;
        Debug.Log("Collider On");
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, true);
        Debug.Log("Is anim to true");


    }

    public void TriggerOnlyDeactivate()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, true);
        Debug.Log("Is on to true");
        animator.SetTrigger("Fade");
        Debug.Log("Start anim");
        this_Collider.enabled = false;
        Debug.Log("Collider Off");
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, true);
        Debug.Log("Is anim to true");

    }

    public void ActivateBarrier()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, true);
        Debug.Log("finished anim, Is on to true");
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, false);
        Debug.Log("Is anim to false, finished anim");

    }

    public void DeactivateBarrier() 
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, false);
        Debug.Log("finished anim, Is on to false");
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, false);
        Debug.Log("Is anim to false, finished anim");

    }
}
