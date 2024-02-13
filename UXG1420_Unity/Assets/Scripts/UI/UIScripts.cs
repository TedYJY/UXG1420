using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class UIScripts : MonoBehaviour
{
    public GameObject W_Pressed;
    public GameObject W_Unpressed;
    public GameObject A_Pressed;
    public GameObject A_Unpressed;
    public GameObject S_Pressed;
    public GameObject S_Unpressed;
    public GameObject D_Pressed;
    public GameObject D_Unpressed;

    private string Keypressed;

    // Start is called before the first frame update
    void Start()
    {
        //Timer();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("w"))
        {
            W_Pressed.SetActive(true);
            W_Unpressed.SetActive(false);
        } 
        else if (Input.GetKeyDown("a")) 
        {
            A_Pressed.SetActive(true);
            A_Unpressed.SetActive(false);
        }
        else if (Input.GetKeyDown("s"))
        {
            S_Pressed.SetActive(true);
            S_Unpressed.SetActive(false);
        }
        else if (Input.GetKeyDown("d"))
        {
            D_Pressed.SetActive(true);
            D_Unpressed.SetActive(false);
        }

        if (Input.GetKeyUp("w"))
        {
            W_Pressed.SetActive(false);
            W_Unpressed.SetActive(true);
        }
        else if (Input.GetKeyUp("a"))
        {
            A_Pressed.SetActive(false);
            A_Unpressed.SetActive(true);
        }
        else if (Input.GetKeyUp("s"))
        {
            S_Pressed.SetActive(false);
            S_Unpressed.SetActive(true);
        }
        else if (Input.GetKeyUp("d"))
        {
            D_Pressed.SetActive(false);
            D_Unpressed.SetActive(true);
        }
    }

    IEnumerator Timer()
    {
        // waits for two seconds before continuing
        yield return new WaitForSeconds(15f);

    }
}
