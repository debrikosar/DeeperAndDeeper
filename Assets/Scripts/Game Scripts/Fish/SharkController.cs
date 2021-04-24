using System;
using System.Collections;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    public static event Action OnCollisionPlayer;
    [SerializeField] Rigidbody2D sharkRb2D;
    [SerializeField] float sharkSpeed;

    private void Start()
    {
        StartCoroutine(SharkRoutine());
    }

    IEnumerator SharkRoutine()
    {
        while (true)
        {
            MovePath();
            yield return new WaitForSeconds(10f);
        }
    }

    private void MovePath()
    {
        sharkRb2D.velocity = new Vector2(UnityEngine.Random.Range(-sharkSpeed, sharkSpeed), 
                                         UnityEngine.Random.Range(-sharkSpeed, sharkSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            OnCollisionPlayer?.Invoke();

        if(!collision.transform.CompareTag("GoldFish"))
            MovePath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Surface"))
            sharkRb2D.velocity = new Vector2(UnityEngine.Random.Range(-sharkSpeed, sharkSpeed), -sharkSpeed);
    }
}
