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
    public int goldCount;

    public GameObject goldFishContainer;

    private void Awake()
    {
        PlayerController.OnCollisionGoldFish += GoldFishCatched;
        ShopController.OnBuyAnythingFish += SpendGold;
    }

    private void Start()
    {
        goldCountText = this.gameObject.GetComponent<TextMeshProUGUI>();
        goldCount = Int32.Parse(goldCountText.text);
        goldFishControllers = new List<GoldFishController>();
    }

    public void GoldFishCatched()
    {
        goldCount++;
        goldCountText.text = goldCount.ToString();
    }

    public void SpendGold(int amount)
    {
        goldCount -= amount;
        goldCountText.text = goldCount.ToString();
    }

    private void OnDestroy()
    {
        PlayerController.OnCollisionGoldFish -= GoldFishCatched;
        ShopController.OnBuyAnythingFish -= SpendGold;
    }
}
