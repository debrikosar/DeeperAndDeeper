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
    private AirBarScript airBarScript;
    private PlayerController playerController;
    private ShopController shopControllerScript;
    private PearlScript pearlScript;

    public GameObject timeManager;
    public GameObject flashligh;
    public GameObject shopController;

    private void Awake()
    {
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        timeManagerScript = GameObject.FindWithTag("TimeManager").GetComponent<TimeManagerScript>();
        airBarScript = GameObject.FindWithTag("AirBar").GetComponent<AirBarScript>();
        pearlScript = GameObject.FindWithTag("PearlCount").GetComponent<PearlScript>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        shopControllerScript = shopController.GetComponent<ShopController>();
    }

    public void LoadFields(SaveData loadData)
    {
        goldCount.text = loadData.goldAmount.ToString();
        pearlScript.pearlCount = loadData.pearlAmount;
        timeManagerScript.playTime = loadData.playTime;
        shopControllerScript.oxygenPrice = loadData.airUpgradePrice;
        shopControllerScript.speedPrice = loadData.speedUpgradePrice;
        airBarScript.airDepletionSpeed = loadData.upgradesStages["Air"];
        playerController.speed = loadData.upgradesStages["Speed"];

        if ((int)loadData.upgradesStages["Speed"] == 1)
            shopControllerScript.BuyFlashlight();

        shopControllerScript.RefreshText();
    }

    public void SaveFields()
    {
        timeManagerScript.SavePlayTime();
        Dictionary<string, float> upgradeInfo = new Dictionary<string, float>();
        upgradeInfo.Add("Air", airBarScript.airDepletionSpeed);
        upgradeInfo.Add("Speed", playerController.speed);
        if(flashligh.activeSelf)
            upgradeInfo.Add("Flashlight", 1);
        else
            upgradeInfo.Add("Flashlight", 0);

        saveStorageScript.SaveData(new SaveData(
            Int32.Parse(goldCount.text),
            Int32.Parse(pearlCount.text),
            saveStorageScript.playTime,
            upgradeInfo,
            shopControllerScript.oxygenPrice,
            shopControllerScript.speedPrice
            ));
    }

    public void SaveFieldsIntoStatistic()
    {
        saveStorageScript.SaveStatistic(new SaveData(
            Int32.Parse(goldCount.text),
            Int32.Parse(pearlCount.text),
            saveStorageScript.playTime,
            new Dictionary<string, float>(),
            1,
            1
            ));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
