using System;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public static event Action OnCloseStartCanvas;
    [SerializeField] private GameObject startCanvas;

    public void CloseStartCanvas()
    {
        OnCloseStartCanvas?.Invoke();
        gameObject.SetActive(false);
    }
}
