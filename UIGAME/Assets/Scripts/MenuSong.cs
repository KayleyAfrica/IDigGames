using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSong : MonoBehaviour
{
    public AudioSource menuSong;

    public AudioClip introSong;
    void Start()
    {
        menuSong.clip = introSong;
        menuSong.Play();
    }
}
