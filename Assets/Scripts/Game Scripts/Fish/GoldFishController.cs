using System.Collections;
using UnityEngine;

public class GoldFishController : MonoBehaviour
{
    [SerializeField] Rigidbody2D goldFishRb2D;
    [SerializeField] float goldFishSpeed;
    [SerializeField] SpriteRenderer goldFishSpriteRenderer;
    [SerializeField] Sprite goldFishLeft;
    [SerializeField] Sprite goldFishRight;

    private float lastPosX;
    private float lastPosY;

    private void Start()
    {
        StartCoroutine(GoldFishRoutine());
        StartCoroutine(CheckIdle());
    }

    IEnumerator GoldFishRoutine()
    {
        while (true)
        {
            MovePath();
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator CheckIdle()
    {
        while (true)
        {
            if (goldFishRb2D.transform.position.x == lastPosX &&
                goldFishRb2D.transform.position.y == lastPosY)
                MovePath();
            lastPosX = goldFishRb2D.transform.position.x;
            lastPosY = goldFishRb2D.transform.position.y;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void MovePath()
    {
        goldFishRb2D.velocity = new Vector2(UnityEngine.Random.Range(-goldFishSpeed, goldFishSpeed), 
                                            UnityEngine.Random.Range(-goldFishSpeed, goldFishSpeed));
        CheckSprite();
    }

    private void CheckSprite()
    {
        if (goldFishRb2D.velocity.x >= 0)
            goldFishSpriteRenderer.sprite = goldFishRight;
        else
            goldFishSpriteRenderer.sprite = goldFishLeft;
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
        {
            goldFishRb2D.velocity = new Vector2(UnityEngine.Random.Range(-goldFishSpeed, goldFishSpeed), -goldFishSpeed);
            CheckSprite();
        }
    }
}
