using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit_Barrier_Active_Script : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

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
        animator.SetTrigger("Fade");
        this_Collider.enabled = true;
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, true);


    }

    public void TriggerOnlyDeactivate()
    {
        animator.SetTrigger("Fade");
        this_Collider.enabled = false;
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, true);

    }

    public void ActivateBarrier()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, true);
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, false);

    }

    public void DeactivateBarrier() 
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, false);
        this.GetComponent<Animator>().SetBool(Is_Animating_Hash, false);

    }
}
