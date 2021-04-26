using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    public DateTime startTime;
    public TimeSpan playTime;

    private SaveStorageScript saveStorageScript;

    void Start()
    {
        startTime = DateTime.Now;
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        AirBarScript.OnOxygenDepletion += SaveDeathPlayTime;
        PlayerController.OnWinning += SaveDeathPlayTime;
    }

    public void SavePlayTime()
    {
        playTime += DateTime.Now - startTime;
        startTime = DateTime.Now;
        saveStorageScript.playTime = playTime;
        Debug.Log(saveStorageScript.playTime);
    }

    public void SaveDeathPlayTime()
    {
        playTime += DateTime.Now - startTime;
        saveStorageScript.playTime = playTime;
        Debug.Log(saveStorageScript.playTime);
    }

}
