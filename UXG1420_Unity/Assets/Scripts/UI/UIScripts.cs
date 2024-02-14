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

    public GameObject E_Parent;

    private bool WASDActive = true;

    private bool EActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //Timer();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("w") && WASDActive == true)
        {
            W_Pressed.SetActive(true);
            W_Unpressed.SetActive(false);
        }
        else if (Input.GetKeyDown("a") && WASDActive == true)
        {
            A_Pressed.SetActive(true);
            A_Unpressed.SetActive(false);
        }
        else if (Input.GetKeyDown("s") && WASDActive == true)
        {
            S_Pressed.SetActive(true);
            S_Unpressed.SetActive(false);
        }
        else if (Input.GetKeyDown("d") && WASDActive == true)
        {
            D_Pressed.SetActive(true);
            D_Unpressed.SetActive(false);
        }

        if (Input.GetKeyUp("w") && WASDActive == true)
        {
            W_Pressed.SetActive(false);
            W_Unpressed.SetActive(true);
        }
        else if (Input.GetKeyUp("a") && WASDActive == true)
        {
            A_Pressed.SetActive(false);
            A_Unpressed.SetActive(true);
        }
        else if (Input.GetKeyUp("s") && WASDActive == true)
        {
            S_Pressed.SetActive(false);
            S_Unpressed.SetActive(true);
        }
        else if (Input.GetKeyUp("d") && WASDActive == true)
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

    public void TurnEActive()
    {
        E_Parent.SetActive(true);

        WASDActive = false;
        W_Pressed.SetActive(false);
        W_Unpressed.SetActive(false);
        A_Pressed.SetActive(false);
        A_Unpressed.SetActive(false);
        S_Pressed.SetActive(false);
        S_Unpressed.SetActive(false);
        D_Pressed.SetActive(false);
        D_Unpressed.SetActive(false);
    }

    public void TurnEInactive()
    {
        E_Parent.SetActive(false);
        WASDActive = true;
    }
}
