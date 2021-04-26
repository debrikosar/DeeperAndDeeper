using System;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public static event Action OnCloseShop;
    public static event Action OnBuyOxygen;
    public static event Action OnBuySpeed;
    public static event Action<int> OnBuyAnythingFish;

    [SerializeField] private GameObject shopCanvas;

    [SerializeField] GoldScript goldScript;
    [SerializeField] TextMeshProUGUI oxygenPriceText;
    [SerializeField] TextMeshProUGUI speedPriceText;
    [SerializeField] TextMeshProUGUI flashlightPriceText;

    [SerializeField] int oxygenPrice;
    [SerializeField] int speedPrice;
    [SerializeField] int flashlightPrice;

    public void Start()
    {
        RefreshText();
    }

    public void BuyOxygen()
    {   if(goldScript.goldCount >= oxygenPrice)
        {
            OnBuyAnythingFish?.Invoke(oxygenPrice);
            oxygenPrice *= 2;
            OnBuyOxygen?.Invoke();
            RefreshText();
        }
    }

    public void BuySpeed()
    {
        if (goldScript.goldCount >= speedPrice)
        {
            OnBuyAnythingFish?.Invoke(speedPrice);
            speedPrice *= 2;
            OnBuySpeed?.Invoke();
            RefreshText();
        }
    }

    public void CloseShop()
    {
        OnCloseShop?.Invoke();
        shopCanvas.SetActive(false);
    }

    private void RefreshText()
    {
        oxygenPriceText.text = oxygenPrice.ToString();
        speedPriceText.text = speedPrice.ToString();
        flashlightPriceText.text = flashlightPrice.ToString();
    }
}
