using System.Collections;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D boatRb2D;
    [SerializeField] private Vector3 startBoatPos;
    [SerializeField] private Vector3 hideBoatPos;
    [SerializeField] private float speedBoatAnimation;

    private void Awake()
    {
        PlayerController.OnStartGame += HideBehindScene;
        PlayerController.OnTouchSurface += MoveToPlayer;
    }

    private void Start()
    {
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

    private void OnDestroy()
    {
        PlayerController.OnStartGame -= HideBehindScene;
        PlayerController.OnTouchSurface -= MoveToPlayer;
    }
}
