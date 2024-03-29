using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScripts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update


    //Button script here is suppose to trigger button pressed and button unpressed, but its not wokring
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
