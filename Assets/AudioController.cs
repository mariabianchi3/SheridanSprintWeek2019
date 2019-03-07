using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //public AudioClip clickButtonSound;
    //public AudioClip shootSound;

    private AudioSource source;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }





}
