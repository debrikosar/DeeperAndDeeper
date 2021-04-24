using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject settingsMenu;

    //change 1 to correct scene name later
    public void PlayGame() =>
        SceneManager.LoadScene(1);

    //smooth switch in progress
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void CloseGame() => Application.Quit();
}
