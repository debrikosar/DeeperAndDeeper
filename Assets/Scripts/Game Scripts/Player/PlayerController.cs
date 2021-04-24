using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb2d;
    [SerializeField] private float speed;
    private float horizontalMove;
    private float verticalMove;
    private Vector2 direction;
    private bool canMove;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        direction = new Vector2(horizontalMove, verticalMove);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(canMove)
            playerRb2d.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            canMove = false;
        }
    }
}
