using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Background;
    public AudioSource inGame;

    public AudioClip backGroundMusic;
    public AudioClip Sfx;


    // Start is called before the first frame update
    void Start()
    {
        Background.clip = backGroundMusic;
        Background.Play();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
