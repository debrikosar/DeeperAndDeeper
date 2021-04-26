using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStorageScript : MonoBehaviour
{
    public bool isLoadingGame;
    public SaveData loadData;
    public SaveData saveData;
    public TimeSpan playTime;

    private SaveManagerScript saveManagerScript;

    private static bool isExisting;

    public void Awake()
    {
        if (isExisting)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        isExisting = true;
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Game")
        {
            saveManagerScript = GameObject.FindWithTag("SaveManager").GetComponent<SaveManagerScript>();

            if (isLoadingGame)
            {
                LoadData();
                saveManagerScript.LoadFields(loadData);
            }
        }
        else if(currentScene.name == "GameEndScene")
        {
            isLoadingGame = false;
            File.Delete(Application.persistentDataPath + "/SaveData.json");
        }
    }

    public void LoadData() => 
        loadData = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(Application.persistentDataPath + "/SaveData.json"));


    public void SaveStatistic(SaveData saveData) => this.saveData = saveData;

    public void SaveData(SaveData saveData) =>
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", JsonConvert.SerializeObject(saveData, Formatting.Indented));       

    public void PrepareForLoading() => isLoadingGame = true;
}
