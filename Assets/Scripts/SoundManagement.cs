using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    public AudioClip tippedGeneric;
    public AudioClip enemyHit;
    public AudioClip enemyDeath;
    public AudioClip levelComplete;
    public AudioClip menuSound1;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "tippedGeneric":
                audioSrc.PlayOneShot(tippedGeneric);
                break;

            case "enemyHit":
                audioSrc.PlayOneShot(enemyHit);
                break;

            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeath);
                break;

            case "levelComplete":
                audioSrc.PlayOneShot(levelComplete);
                break;

            case "menuSound1":
                audioSrc.PlayOneShot(menuSound1);
                break;
        }
    }
}
