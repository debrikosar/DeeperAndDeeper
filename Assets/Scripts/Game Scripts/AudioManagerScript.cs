using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioClip[] sounds;

    public AudioSource soundsSource;

    private SaveStorageScript saveStorageScript;

    private void Start()
    {
        PlayerController.OnCollisionGoldFish += PlayGoldfishSound;
        PlayerController.OnPickUpSpeedBuff += PlaySpeedBoostSound;
        PlayerController.OnPickUpOxygenBuff += PlayAirBallonSound;
        PlayerController.OnCollisionShark += PlaySharkBiteSound;
        PlayerController.OnTouchSurface += PlaySplashSound;
        PlayerController.OnCollisionWeed += PlaySeaweedSound;
        PlayerController.OnPickUpGigaPearl += PlayGigaperalSound;
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        soundsSource.volume = saveStorageScript.soundsVolume;
    }

    public void PlayGoldfishSound()
    {
        soundsSource.clip = sounds[0];
        soundsSource.Play();
    }

    public void PlaySpeedBoostSound()
    {
        soundsSource.clip = sounds[1];
        soundsSource.Play();
    }

    public void PlayAirBallonSound()
    {
        soundsSource.clip = sounds[2];
        soundsSource.Play();
    }

    public void PlaySharkBiteSound()
    {
        soundsSource.clip = sounds[3];
        soundsSource.Play();
    }

    public void PlaySplashSound(float temp)
    {
        soundsSource.clip = sounds[4];
        soundsSource.Play();
    }

    public void PlaySeaweedSound()
    {
        soundsSource.clip = sounds[5];
        soundsSource.Play();
    }

    public void PlayGigaperalSound()
    {
        soundsSource.clip = sounds[6];
        soundsSource.Play();
    }
}
