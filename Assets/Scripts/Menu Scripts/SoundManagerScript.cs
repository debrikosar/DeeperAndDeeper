using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioSource musicSource;
    public List<AudioSource> soundSources;

    public void ChangeMusicVolume(float musicVolume) =>
        musicSource.volume = musicVolume;

    public void ChangeSoundsVolume(float soundVolume)
    {
        foreach (AudioSource soundSource in soundSources)
            soundSource.volume = soundVolume;
    }
}
