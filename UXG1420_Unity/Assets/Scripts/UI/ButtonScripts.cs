using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScripts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    public GameObject ButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("gay");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("not gay");
    }
}
