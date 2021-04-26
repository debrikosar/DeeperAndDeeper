using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<float> OnTouchSurface;
    public static event Action<bool> OnUnderWater;
    public static event Action OnPickUpPearl;
    public static event Action OnPickUpOxygenBuff;
    public static event Action OnCollisionShark;
    public static event Action OnCollisionGoldFish;

    [SerializeField] private Rigidbody2D playerRb2d;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private float speed;

    private float horizontalMove;
    private float verticalMove;
    private bool canMove;

    private void Awake()
    {
        StartController.OnCloseStartCanvas += JumpInWater;
        ShopController.OnCloseShop += JumpInWater;
    } 

    private void Start()
    {
        transform.position = startPoint.transform.position;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void JumpInWater()
    {
        OnUnderWater?.Invoke(true);
        StartCoroutine(JumpRoutine());
    }

    private void Move()
    {
        if (canMove)
        {
            Vector2 direction = new Vector2(horizontalMove, verticalMove);
            playerRb2d.position += direction * speed * Time.deltaTime;
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            OnTouchSurface?.Invoke(transform.position.x);
            OnUnderWater?.Invoke(false);
            canMove = false;
        }

        if (collision.CompareTag("Seaweed"))
        {
            StartCoroutine(TouchSeaweedRoutine());
        }

        if (collision.CompareTag("Pearl"))
        {
            OnPickUpPearl?.Invoke();
        }

        if (collision.CompareTag("SpeedBuff"))
        {
            StartCoroutine(PickUpSpeedBuff());
        }

        if (collision.CompareTag("OxygenBuff"))
        {
            OnPickUpOxygenBuff?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shark"))
        {
            OnCollisionShark?.Invoke();
        }

        if (collision.collider.CompareTag("GoldFish"))
        {
            OnCollisionGoldFish?.Invoke();
        }
    }

    IEnumerator JumpRoutine()
    {
        playerRb2d.AddForce(-transform.up * 100000f);
        yield return new WaitForSeconds(2f);
        canMove = true;
        playerRb2d.Sleep();
    }

    IEnumerator TouchSeaweedRoutine()
    {
        canMove = false;
        yield return new WaitForSeconds(2f);
        canMove = true;
    }

    IEnumerator PickUpSpeedBuff()
    {
        speed *= 2;
        yield return new WaitForSeconds(5f);
        speed /= 2;
    }

    private void OnDestroy()
    {
        StartController.OnCloseStartCanvas -= JumpInWater;
        ShopController.OnCloseShop -= JumpInWater;
    }
}
