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

    private SaveStorageScript saveStorageScript;

    private void Start()
    {
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
    }

    public void LoadFields(SaveData loadData)
    {
        goldCount.text = loadData.goldAmount.ToString();
    }

    public void SaveFields()
    {
        saveStorageScript.SaveData(new SaveData(Int32.Parse(goldCount.text)));
    }
}
