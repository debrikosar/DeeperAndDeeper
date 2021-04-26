using System.Collections;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    [SerializeField] Rigidbody2D sharkRb2D;
    [SerializeField] float sharkSpeed;
    [SerializeField] SpriteRenderer sharkSpriteRenderer;
    [SerializeField] Sprite sharkLeft;
    [SerializeField] Sprite sharkRight;

    private float lastPosX;
    private float lastPosY;

    private void Start()
    {
        StartCoroutine(SharkRoutine());
        StartCoroutine(CheckIdle());
    }

    IEnumerator SharkRoutine()
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
            if (sharkRb2D.transform.position.x == lastPosX &&
                sharkRb2D.transform.position.y == lastPosY)
                MovePath();
            lastPosX = sharkRb2D.transform.position.x;
            lastPosY = sharkRb2D.transform.position.y;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void MovePath()
    {
        sharkRb2D.velocity = new Vector2(UnityEngine.Random.Range(-sharkSpeed, sharkSpeed), 
                                         UnityEngine.Random.Range(-sharkSpeed, sharkSpeed));
        CheckSprite();
    }

    private void CheckSprite()
    {
        if (sharkRb2D.velocity.x >= 0)
            sharkSpriteRenderer.sprite = sharkRight;
        else
            sharkSpriteRenderer.sprite = sharkLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.transform.CompareTag("GoldFish"))
            MovePath();
        else
            CheckSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SurfaceFish"))
        {
            sharkRb2D.velocity = new Vector2(UnityEngine.Random.Range(-sharkSpeed, sharkSpeed), -sharkSpeed);
            CheckSprite();
        }
    }
}
