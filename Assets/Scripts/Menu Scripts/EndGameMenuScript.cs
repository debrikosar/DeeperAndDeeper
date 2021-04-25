using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EndGameMenuScript : MonoBehaviour
{
    public TextMeshProUGUI goldAmount;
    private SaveStorageScript saveStorageScript;

    private void Start()
    {
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        goldAmount.text = saveStorageScript.saveData.goldAmount.ToString();
    }

    public void CloseGame() => 
        Application.Quit();
    public void SwitchSceneToGame() 
    {
        Debug.Log("bruh");
        SceneManager.LoadScene("Game");
    }

}
