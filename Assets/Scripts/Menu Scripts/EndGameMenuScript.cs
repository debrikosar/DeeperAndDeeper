using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EndGameMenuScript : MonoBehaviour
{
    public TextMeshProUGUI goldAmount;
    public TextMeshProUGUI pearlAmount;
    public TextMeshProUGUI timeAmount;
    private SaveStorageScript saveStorageScript;

    private void Start()
    {
        saveStorageScript = GameObject.FindWithTag("SaveStorage").GetComponent<SaveStorageScript>();
        goldAmount.text = saveStorageScript.saveData.goldAmount.ToString();
        pearlAmount.text = saveStorageScript.saveData.pearlAmount.ToString();
        timeAmount.text = saveStorageScript.saveData.playTime.ToString().Substring(0, 8);
    }

    public void CloseGame() => 
        Application.Quit();
    public void SwitchSceneToGame() 
    {
        SceneManager.LoadScene("Game");
    }

}
