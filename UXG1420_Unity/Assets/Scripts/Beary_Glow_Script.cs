using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Beary_Glow_Script : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public bool IsActive;
    
    private static readonly int Is_On_Hash = Animator.StringToHash("Is_On");
    private static readonly int Is_Animating_Hash = Animator.StringToHash("Is_Animating");

    

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().SetBool(Is_On_Hash, IsActive);
        //Beary_Renderer = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerGlow()
    {


        animator.SetTrigger("Fade");
        animator.SetBool(Is_Animating_Hash, true);


    }

    public void TriggerOnlyActivate()
    {
        animator.SetBool(Is_On_Hash, false);
        animator.SetTrigger("Fade");
        animator.SetBool(Is_Animating_Hash, true);


    }

    public void TriggerOnlyDeactivate()
    {
        animator.SetBool(Is_On_Hash, true);
        animator.SetTrigger("Fade");
        animator.SetBool(Is_Animating_Hash, true);

    }

    public void ActivateGlow()
    {
        animator.SetBool(Is_On_Hash, true);
        animator.SetBool(Is_Animating_Hash, false);

    }

    public void DeactivateGlow()
    {
        animator.SetBool(Is_On_Hash, false);
        animator.SetBool(Is_Animating_Hash, false);

    }

}
