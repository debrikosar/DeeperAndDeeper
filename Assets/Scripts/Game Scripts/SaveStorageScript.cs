using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStorageScript : MonoBehaviour
{
    public bool isLoadingGame;

    public SaveData loadData;

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
        saveManagerScript = GameObject.FindWithTag("SaveManager").GetComponent<SaveManagerScript>();

        if (isLoadingGame)
        {
            LoadData();
            saveManagerScript.LoadFields(loadData);
        }
    }

    public void LoadData() => 
        loadData = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(Application.persistentDataPath + "/SaveData.json"));

    public void SaveData(SaveData saveData) =>
         File.WriteAllText(Application.persistentDataPath + "/SaveData.json", JsonConvert.SerializeObject(saveData, Formatting.Indented));

    public void PrepareForLoading() => isLoadingGame = true;
}
