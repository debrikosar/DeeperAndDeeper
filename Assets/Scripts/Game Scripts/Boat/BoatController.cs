using System.Collections;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D boatRb2D;
    [SerializeField] private Vector3 startBoatPos;
    [SerializeField] private Vector3 hideBoatPos;
    [SerializeField] private float speedBoatAnimation;
    private bool firstJump;

    private void Awake()
    {
        StartController.OnCloseStartCanvas += HideBehindScene;
        PlayerController.OnTouchSurface += MoveToPlayer;
        ShopController.OnCloseShop += HideBehindScene;
    }

    private void Start()
    {
        firstJump = true;
        transform.position = startBoatPos;
    }

    private void HideBehindScene()
    {
        StartCoroutine(BoatHideAnimationRoutine(hideBoatPos));
    }

    private void MoveToPlayer(float posX)
    {
        Vector3 destination = new Vector3(posX, transform.position.y, transform.position.z);
        StartCoroutine(BoatShowAnimationRoutine(destination));
    }

    IEnumerator BoatHideAnimationRoutine(Vector3 destination)
    {
        while (transform.position.x <= destination.x)
        {
            boatRb2D.MovePosition(transform.position + transform.right * speedBoatAnimation);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator BoatShowAnimationRoutine(Vector3 destination)
    {
        while (transform.position.x >= destination.x)
        {
            boatRb2D.MovePosition(transform.position + -transform.right * speedBoatAnimation);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !firstJump)
        {
            shopCanvas.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Player") && firstJump)
        {
            startCanvas.SetActive(true);
            firstJump = false;
        }
    }

    private void OnDestroy()
    {
        StartController.OnCloseStartCanvas -= HideBehindScene;
        PlayerController.OnTouchSurface -= MoveToPlayer;
        ShopController.OnCloseShop -= HideBehindScene;
    }
}
