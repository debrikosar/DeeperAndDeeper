using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<float> OnTouchSurface;
    public static event Action OnStartGame;
    [SerializeField] private Rigidbody2D playerRb2d;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject startPoint;
    private float horizontalMove;
    private float verticalMove;
    private Vector2 direction;
    private bool canMove;
    private int surfaceTouchCount;

    private void Start()
    {
        surfaceTouchCount = 1;
        transform.position = startPoint.transform.position;
    }

    private void Update()
    {
        if(!canMove && Input.GetKeyDown(KeyCode.Space))
        {
            OnStartGame?.Invoke();
            StartCoroutine(JumpRoutine());
        }
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        direction = new Vector2(horizontalMove, verticalMove);
    }

    private void FixedUpdate()
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
            OnTouchSurface?.Invoke(transform.position.x);
            canMove = false;
        }
    }

    IEnumerator JumpRoutine()
    {
        playerRb2d.AddForce(-transform.up * 100f);
        yield return new WaitForSeconds(2f);
        canMove = true;
        playerRb2d.Sleep();
    }
}
