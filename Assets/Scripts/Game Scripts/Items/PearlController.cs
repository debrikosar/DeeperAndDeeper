using System;
using UnityEngine;

public class PearlController : MonoBehaviour
{
    public event Action OnPearlPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPearlPickUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
