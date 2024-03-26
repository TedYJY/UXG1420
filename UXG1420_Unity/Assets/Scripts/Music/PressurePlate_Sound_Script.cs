using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PressurePlate_Sound_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject Level_MusicHandler;
    [SerializeField]
    private AudioClip Push_Sound;
    [SerializeField]
    private AudioClip Release_Sound;

    public void PlayPush()
    {
        Level_MusicHandler.GetComponent<MusicClass>().PlaySound(Push_Sound);
    }

    public void PlayRelease()
    {
        Level_MusicHandler.GetComponent<MusicClass>().PlaySound(Release_Sound);
    }
}
