using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speedBoatAnimation;
    private bool isBoatIdle;
    private Vector3 startBoatPos;

    private void Awake()
    {
        PlayerController.OnTouchSurface += MoveToPlayer;
    }

    private void Start()
    {
        isBoatIdle = true;
    }

    private void Update()
    {
        if(isBoatIdle)
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z) + offset;
    }

    private void MoveToPlayer(float posX)
    {
        isBoatIdle = false;
        startBoatPos = transform.position;
        Vector3 destination = new Vector3(posX, transform.position.y, transform.position.z);
        StartCoroutine(BoatAnimationRoutine(destination));
    }

    IEnumerator BoatAnimationRoutine(Vector3 destination)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speedBoatAnimation * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
