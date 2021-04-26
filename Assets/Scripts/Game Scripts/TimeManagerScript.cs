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
        AirBarScript.OnOxygenDepletion += SavePlayTime;
    }

    public void SavePlayTime()
    {
        playTime = DateTime.Now - startTime;
        saveStorageScript.playTime = playTime;
    }

}
