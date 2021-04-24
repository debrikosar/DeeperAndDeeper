using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject settingsMenu;

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
        saveStorageScript.PrepareForLoading();
        SwitchSceneToGame();
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
