using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioClip[] music;

    public AudioSource soundsSource;
    public AudioSource musicSource;

    private SaveStorageScript saveStorageScript;

    private void Start()
    {
        musicSource = GameObject.FindWithTag("MusicSource").GetComponent<AudioSource>();

        PlayerController.OnCollisionGoldFish += PlayGoldfishSound;
        PlayerController.OnPickUpSpeedBuff += PlaySpeedBoostSound;
        PlayerController.OnPickUpOxygenBuff += PlayAirBallonSound;
        PlayerController.OnCollisionShark += PlaySharkBiteSound;
        PlayerController.OnTouchSurface += PlaySplashSound;
        PlayerController.OnCollisionWeed += PlaySeaweedSound;
        PlayerController.OnPickUpGigaPearl += PlayGigaperalSound;
        PlayerController.OnWinning += PlayCalmMusic;
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
        musicSource.clip = sounds[1];
        soundsSource.Play();
        musicSource.Play();
    }

    public void PlayCalmMusic()
    {
        musicSource.clip = sounds[0];
        musicSource.Play();
    }

    private void OnDestroy()
    {
        PlayerController.OnCollisionGoldFish -= PlayGoldfishSound;
        PlayerController.OnPickUpSpeedBuff -= PlaySpeedBoostSound;
        PlayerController.OnPickUpOxygenBuff -= PlayAirBallonSound;
        PlayerController.OnCollisionShark -= PlaySharkBiteSound;
        PlayerController.OnTouchSurface -= PlaySplashSound;
        PlayerController.OnCollisionWeed -= PlaySeaweedSound;
        PlayerController.OnPickUpGigaPearl -= PlayGigaperalSound;
        PlayerController.OnWinning -= PlayCalmMusic;
    }
}
