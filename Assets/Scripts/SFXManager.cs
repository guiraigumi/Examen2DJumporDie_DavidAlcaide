using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip monedaSFX;
    public AudioClip bombSFX;
    public AudioClip jumpSFX;
    

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void MonedaSound()
    {
        _audioSource.PlayOneShot(monedaSFX);
    }

    public void JumpSound()
    {
        _audioSource.PlayOneShot(jumpSFX);
    }
    public void BombSound()
    {
        _audioSource.PlayOneShot(bombSFX);
    }
}
