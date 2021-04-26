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

    public GameObject timeManager;

    private void Awake()
    {
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        timeManagerScript = GameObject.FindWithTag("TimeManager").GetComponent<TimeManagerScript>();
    }

    public void LoadFields(SaveData loadData)
    {
        goldCount.text = loadData.goldAmount.ToString();
        pearlCount.text = loadData.pearlAmount.ToString();
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
}
