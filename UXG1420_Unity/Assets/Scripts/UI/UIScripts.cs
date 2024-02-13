using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.SetActive(false);

        if (Input.GetMouseButtonDown(0))//Input.GetMouseButtonDown(0)
        {
            gameObject.SetActive(false);
            Debug.Log("ok works");
            //LoadNextLevel();
        } //*/
    }

    /*IEnumerator myDelay()
    {
        // waits for two seconds before continuing
        yield return new WaitForSeconds(2f);

        if (stopText == true)
        {
            objectToEnable4.SetActive(false);
        }
    } //*/
}
