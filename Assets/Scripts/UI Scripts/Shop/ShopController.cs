using System;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public static event Action OnCloseShop;
    public static event Action OnBuyOxygen;
    public static event Action OnBuySpeed;
    public static event Action OnBuyFlashlight;
    public static event Action<int> OnBuyAnything;
    public static event Action<int> OnBuyAnythingPearl;

    [SerializeField] private GameObject shopCanvas;

    [SerializeField] GoldScript goldScript;
    [SerializeField] PearlScript pearlScript;
    [SerializeField] TextMeshProUGUI oxygenPriceText;
    [SerializeField] TextMeshProUGUI speedPriceText;
    [SerializeField] TextMeshProUGUI flashlightPriceText;

    [SerializeField] public int oxygenPrice;
    [SerializeField] public int speedPrice;
    [SerializeField] int flashlightPrice;

    public void Start()
    {
        RefreshText();
    }

    public void BuyOxygen()
    {   if(goldScript.goldCount >= oxygenPrice)
        {
            OnBuyAnything?.Invoke(oxygenPrice);
            oxygenPrice *= 2;
            OnBuyOxygen?.Invoke();
            RefreshText();
        }
    }

    public void BuySpeed()
    {
        if (goldScript.goldCount >= speedPrice)
        {
            OnBuyAnything?.Invoke(speedPrice);
            speedPrice *= 2;
            OnBuySpeed?.Invoke();
            RefreshText();
        }
    }

    public void BuyFlashlight()
    {
        if (pearlScript.pearlCount >= flashlightPrice)
        {
            OnBuyAnythingPearl?.Invoke(flashlightPrice);
            OnBuyFlashlight?.Invoke();
            flashlightPrice = 0;
            flashlightPriceText.text = "";
        }
    }

    public void CloseShop()
    {
        OnCloseShop?.Invoke();
        shopCanvas.SetActive(false);
    }

    public void RefreshText()
    {
        oxygenPriceText.text = oxygenPrice.ToString();
        speedPriceText.text = speedPrice.ToString();
        flashlightPriceText.text = flashlightPrice.ToString();
    }
}
