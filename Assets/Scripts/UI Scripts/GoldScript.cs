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

        PlayerController.OnCollisionGoldFish += OnGoldFishCatched;
    }

    public void OnGoldFishCatched()
    {
        goldCount++;
        goldCountText.text = goldCount.ToString();
    }

    private void OnDestroy()
    {
        PlayerController.OnCollisionGoldFish -= OnGoldFishCatched;
    }
}
