using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut1_TorchUITrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            GameObject.FindWithTag("UI").GetComponent<UIScripts>().TurnEActive();
        }

        catch
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            GameObject.FindWithTag("UI").GetComponent<UIScripts>().TurnEInactive();
        }

        catch
        {

        }
    }
}
