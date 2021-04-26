using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldScript : MonoBehaviour
{
    private TextMeshProUGUI goldCountText;
    public int goldCount;

    private void Awake()
    {
        PlayerController.OnCollisionGoldFish += GoldFishCatched;
        ShopController.OnBuyAnythingFish += SpendGold;
    }

    private void Start()
    {
        goldCountText = this.gameObject.GetComponent<TextMeshProUGUI>();
        goldCount = Int32.Parse(goldCountText.text);
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
