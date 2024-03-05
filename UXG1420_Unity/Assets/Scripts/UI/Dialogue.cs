using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; //name of the character thats talking

    [TextArea(3,10)] //defines text area in the inspector

    public string[] sentences; //list of dialogue sentences
}
