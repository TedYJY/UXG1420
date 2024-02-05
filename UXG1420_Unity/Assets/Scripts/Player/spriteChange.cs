using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteChange : MonoBehaviour
{

    public SpriteRenderer spriteComp;
    public Sprite main;
    public Sprite possessed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spritePossess()
    {
        spriteComp.sprite = possessed;
    }

    public void spriteUnpossess()
    {
        spriteComp.sprite = main;
    }
}
