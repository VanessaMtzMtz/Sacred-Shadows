using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioClip[] sFXClips;

    public static SFXManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void PlayFear()
    {
        sfxAudioSource.PlayOneShot(sFXClips[0]);
    }

    public void PlayGhostBreath()
    {
        sfxAudioSource.PlayOneShot(sFXClips[1]);
    }

    public void PlayFireCamp()
    {
        sfxAudioSource.PlayOneShot(sFXClips[2]);
    }

    public void StopFear()
    {
        sfxAudioSource.Stop();
    }


}
