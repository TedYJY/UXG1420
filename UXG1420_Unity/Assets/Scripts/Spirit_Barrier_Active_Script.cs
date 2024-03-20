using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit_Barrier_Active_Script : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    public bool IsActive;

    private static readonly int Is_On_Hash = Animator.StringToHash("Is_On");

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
        this_Collider.enabled = !this_Collider.enabled;
        animator.SetTrigger("Fade");
    }

    public void TriggerOnlyDeactivate()
    {
        this_Collider.enabled = false;
        animator.SetTrigger("Fade");
    }

    public void ActivateBarrier()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, true);
    }

    public void DeactivateBarrier() 
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, false);
    }
}
