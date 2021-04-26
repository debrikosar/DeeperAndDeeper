using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PearlScript : MonoBehaviour
{
    private TextMeshProUGUI pearlCountText;
    public int pearlCount;

    private void Awake()
    {
        PlayerController.OnPickUpPearl += PearlPickedUp;
    }

    private void Start()
    {
        pearlCountText = this.gameObject.GetComponent<TextMeshProUGUI>();
        pearlCount = Int32.Parse(pearlCountText.text);
    }

    public void PearlPickedUp()
    {
        pearlCount++;
        pearlCountText.text = pearlCount.ToString();
    }

    public void SpendPearl(int amount)
    {
        pearlCount -= amount;
        pearlCountText.text = pearlCount.ToString();
    }

    private void OnDestroy()
    {
        PlayerController.OnPickUpPearl -= PearlPickedUp;
    }
}
