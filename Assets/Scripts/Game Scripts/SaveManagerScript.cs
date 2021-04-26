using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using System;

public class SaveManagerScript : MonoBehaviour
{     
    public TextMeshProUGUI goldCount;
    public TextMeshProUGUI pearlCount;

    private SaveStorageScript saveStorageScript;
    private TimeManagerScript timeManagerScript;
    private PearlScript pearlScript;

    public GameObject timeManager;

    private void Awake()
    {
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        timeManagerScript = GameObject.FindWithTag("TimeManager").GetComponent<TimeManagerScript>();
        pearlScript = GameObject.FindWithTag("PearlCount").GetComponent<PearlScript>();
    }

    public void LoadFields(SaveData loadData)
    {
        goldCount.text = loadData.goldAmount.ToString();
        pearlScript.pearlCount = loadData.pearlAmount;
        timeManagerScript.playTime = loadData.playTime;
    }

    public void SaveFields()
    {
        timeManagerScript.SavePlayTime();
        saveStorageScript.SaveData(new SaveData(Int32.Parse(goldCount.text), Int32.Parse(pearlCount.text), saveStorageScript.playTime));
    }

    public void SaveFieldsIntoStatistic()
    {
        saveStorageScript.SaveStatistic(new SaveData(Int32.Parse(goldCount.text), Int32.Parse(pearlCount.text), saveStorageScript.playTime));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
