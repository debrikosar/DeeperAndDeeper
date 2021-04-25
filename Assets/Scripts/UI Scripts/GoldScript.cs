using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldScript : MonoBehaviour
{
    private GameObject[] goldFishes;
    private List<GoldFishController> goldFishControllers;

    private TextMeshProUGUI goldCountText;
    private int goldCount;

    public GameObject goldFishContainer;

    private void Start()
    {
        goldCountText = this.gameObject.GetComponent<TextMeshProUGUI>();
        goldCount = Int32.Parse(goldCountText.text);
        goldFishControllers = new List<GoldFishController>();

        foreach (Transform child in goldFishContainer.transform)
        {
            if (child.gameObject.tag == "GoldFish")
            {
                goldFishControllers.Add(child.gameObject.GetComponent<GoldFishController>());
            }
        }

        foreach (GoldFishController goldFishController in goldFishControllers)
            goldFishController.OnCollisionPlayer += OnGoldFishCatched;
    }

    public void OnGoldFishCatched()
    {
        goldCount++;
        goldCountText.text = goldCount.ToString();
    }
}
