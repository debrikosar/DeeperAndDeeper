using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static event Action<float> OnTouchSurface;
    public static event Action<bool> OnUnderWater;
    public static event Action OnPickUpPearl;
    public static event Action OnPickUpGigaPearl;
    public static event Action OnPickUpOxygenBuff;
    public static event Action OnPickUpSpeedBuff;
    public static event Action OnCollisionShark;
    public static event Action OnCollisionGoldFish;
    public static event Action OnCollisionWeed;

    [SerializeField] private Rigidbody2D playerRb2d;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private GameObject bubbles;
    [SerializeField] private Vector3 bubblesPosRight;
    [SerializeField] private Vector3 bubblesPosLeft;
    [SerializeField] private float speed;

    private SaveManagerScript saveManagerScript;

    private float horizontalMove;
    private float verticalMove;
    private bool canMove;
    private bool winCondition;

    private void Awake()
    {
        saveManagerScript = GameObject.FindWithTag("SaveManager").GetComponent<SaveManagerScript>();
        StartController.OnCloseStartCanvas += JumpInWater;
        ShopController.OnCloseShop += JumpInWater;
        ShopController.OnBuySpeed += AddSpeed;
        ShopController.OnBuyFlashlight += AddFlashLight;
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
            if (horizontalMove > 0)
            {
                animator.SetBool("IsRight", true);
                bubbles.transform.localPosition = bubblesPosRight;
            }
            else if(horizontalMove < 0)
            {
                animator.SetBool("IsRight", false);
                bubbles.transform.localPosition = bubblesPosLeft;
            }
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            if (!winCondition)
            {
                OnTouchSurface?.Invoke(transform.position.x);
                OnUnderWater?.Invoke(false);
                canMove = false;
            }
            else
            {
                print("WIN");
                saveManagerScript.SaveFieldsIntoStatistic();
                SceneManager.LoadScene("WinScene");
            }
        }

        if (collision.CompareTag("Seaweed"))
        {
            OnCollisionWeed?.Invoke();
            StartCoroutine(TouchSeaweedRoutine());
        }

        if (collision.CompareTag("Pearl"))
        {
            OnPickUpPearl?.Invoke();
        }

        if (collision.CompareTag("GigaPearl"))
        {
            winCondition = true;
        }

        if (collision.CompareTag("SpeedBuff"))
        {
            OnPickUpSpeedBuff?.Invoke();
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
        speed += 5;
        yield return new WaitForSeconds(5f);
        speed -= 5;
    }

    private void AddSpeed()
    {
        speed++;
    }

    private void AddFlashLight()
    {
        flashLight.SetActive(true);
    }

    private void OnDestroy()
    {
        StartController.OnCloseStartCanvas -= JumpInWater;
        ShopController.OnCloseShop -= JumpInWater;
        ShopController.OnBuySpeed -= AddSpeed;
        ShopController.OnBuyFlashlight -= AddFlashLight;
    }
}
