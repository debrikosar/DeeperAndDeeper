using System;
using System.Collections;
using UnityEngine;

public class GoldFishController : MonoBehaviour
{
    public static event Action OnCollisionPlayer;
    [SerializeField] Rigidbody2D fishRb2D;

    private void Start()
    {
        StartCoroutine(GoldFishRoutine());
    }

    IEnumerator GoldFishRoutine()
    {
        while (true)
        {
            MovePath();
            yield return new WaitForSeconds(10f);
        }
    }

    private void MovePath()
    {
        fishRb2D.velocity = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnCollisionPlayer?.Invoke();
            Destroy(gameObject);
        }
        MovePath();
    }
}
