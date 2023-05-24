using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTheme : MonoBehaviour
{
    public AudioSource mainMenu;

    public AudioClip themeSong;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.clip = themeSong;
        mainMenu.Play();
    }
}
