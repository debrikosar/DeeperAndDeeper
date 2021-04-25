using System.Collections;
using UnityEngine;

public class GoldFishController : MonoBehaviour
{
    [SerializeField] Rigidbody2D goldFishRb2D;
    [SerializeField] float goldFishSpeed;

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
        goldFishRb2D.velocity = new Vector2(UnityEngine.Random.Range(-goldFishSpeed, goldFishSpeed), 
                                            UnityEngine.Random.Range(-goldFishSpeed, goldFishSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        MovePath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SurfaceFish"))
            goldFishRb2D.velocity = new Vector2(UnityEngine.Random.Range(-goldFishSpeed, goldFishSpeed), -goldFishSpeed);
    }
}
