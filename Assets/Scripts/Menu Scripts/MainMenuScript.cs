using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject warning;

    public GameObject saveStorage;
    private SaveStorageScript saveStorageScript;

    private void Start()
    {
        saveStorageScript = saveStorage.GetComponent<SaveStorageScript>();
    }

    /*public void PlayNewGame()
    {
        SwitchSceneToGame();
    }*/

    public void PlayLoadedGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.json"))
        {
            saveStorageScript.PrepareForLoading();
            SwitchSceneToGame();
        }
        else
            warning.SetActive(true);
    }

    public void CloseWarning()
    {
        warning.SetActive(false);
    }

    public void SwitchSceneToGame() =>
        SceneManager.LoadScene(1);

    //smooth switch in progress
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void CloseGame() => Application.Quit();
}
