using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_ObjectiveHandler : MonoBehaviour
{

    [SerializeField]
    private int objectiveNumber;

    [SerializeField]
    private GameObject objective1;
    [SerializeField]
    private GameObject objective2;
    [SerializeField]
    private GameObject objective3;
    [SerializeField]
    private GameObject objective4;

    // Start is called before the first frame update
    void Start()
    {
        objectiveNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeObjective()
    {
        switch (objectiveNumber)
        {
            case 1:
                objective1.SetActive(false);
                objective2.SetActive(true);
                break;

            case 2:
                objective2.SetActive(false);
                objective3.SetActive(true);
                break;

            case 3:
                objective3.SetActive(false);
                objective4.SetActive(true);
                break;

            default: 
                break;
        }
    }

    public void ManualChangeObjective()
    {
        ChangeObjective();
        objectiveNumber++;
    }

}
