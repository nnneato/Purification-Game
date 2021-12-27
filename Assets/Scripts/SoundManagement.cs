using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    public AudioClip tippedGeneric;
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
        }
    }
}
