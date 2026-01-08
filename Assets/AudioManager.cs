using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;

    public AudioClip shootSFX;
    public AudioClip hitSFX;
    public AudioClip explosionSFX;
    public AudioClip uiClickSFX;

    public AudioClip gameOvers;

    public AudioClip missionsita;
    void Awake()
    {
        if (instance == null)
            instance = this;
            
        else
            Destroy(gameObject);
            
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}