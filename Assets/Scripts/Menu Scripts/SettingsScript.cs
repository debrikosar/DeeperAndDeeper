using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject soundsObject;
    public GameObject musicObject;
    private Slider soundSlider;
    private Slider musicSlider;

    public GameObject soundManager;
    private SoundManagerScript soundManagerScript;

    private void Start()
    {
        soundSlider = soundsObject.GetComponent<Slider>();
        musicSlider = musicObject.GetComponent<Slider>();
        soundManagerScript = soundManager.GetComponent<SoundManagerScript>();
    }

    public void ChangeSoundVolume() =>
        soundManagerScript.ChangeSoundsVolume(soundSlider.value);

    public void ChangeMusicVolume() =>
        soundManagerScript.ChangeMusicVolume(musicSlider.value);

    //smooth switch in progress
    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
