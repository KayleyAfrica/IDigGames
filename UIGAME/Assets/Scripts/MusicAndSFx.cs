using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSFx : MonoBehaviour
{
    public AudioSource BackgroundNusic;
    public AudioSource SFx;
    public AudioSource UpgradeSFx;

    public AudioClip TheSong;
    public AudioClip OnBuy;
    public AudioClip UpgradeSpace;

    void Start()
    {
        BackgroundNusic.clip = TheSong;
        BackgroundNusic.Play();
    }
}
