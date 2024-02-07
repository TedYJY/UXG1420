using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapping : MonoBehaviour
{
    public GameObject cameraRef;
    public GameObject currentPlayer;
    public GameObject targetedPlayer;
    public GameObject ghost;

    public bool targetIsNearby = false;
    public bool isAble;
    public static bool isGhost = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            AttemptPossess();
        }
    }

    private void AttemptPossess()
    {
        if (targetIsNearby == true && isGhost == true)
        {
            //Change to nearby character
            cameraRef.GetComponent<cameraTracking>().ChangeTarget(targetedPlayer);
            targetedPlayer.GetComponent<movement>().enabled = true;
            targetedPlayer.GetComponent<CapsuleCollider2D>().enabled = true;
            targetedPlayer.GetComponent<swapping>().enabled = true;
            targetedPlayer.GetComponent<swapping>().currentPlayer = targetedPlayer;
            targetedPlayer.GetComponent<BoxCollider2D>().enabled = false;

            currentPlayer.SetActive(false);
            targetIsNearby = false;
            isGhost = false;
        }

        else if (isGhost == false && targetIsNearby == false)
        {
            //Change into ghost
            isGhost = true;
            ghost.transform.position = currentPlayer.transform.position;
            cameraRef.GetComponent<cameraTracking>().ChangeTarget(ghost);
            currentPlayer.GetComponent<movement>().enabled = false;
            currentPlayer.GetComponent<CapsuleCollider2D>().enabled = false;
            currentPlayer.GetComponent<BoxCollider2D>().enabled = true;
            currentPlayer.GetComponent<swapping>().enabled = false;

            ghost.SetActive(true);
        }

    }
}
