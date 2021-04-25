using System;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static event Action OnCloseShop;
    [SerializeField] private GameObject shopCanvas;

    public void CloseShop()
    {
        OnCloseShop?.Invoke();
        shopCanvas.SetActive(false);
    }
}
