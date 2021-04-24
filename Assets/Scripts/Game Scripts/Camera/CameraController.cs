using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer sea;
    private float restrictX;
    private float restrictYup;
    private float restrictYdown;

    private void Start()
    {
        float cameraSize = Camera.main.orthographicSize;
        restrictX = sea.size.x/2 - cameraSize*1.75f;
        restrictYdown = sea.size.y / 2 - cameraSize*0.95f;
        restrictYup = sea.size.y/ 2;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -restrictX, restrictX),
                                         Mathf.Clamp(player.position.y, -restrictYdown, restrictYup),
                                         transform.position.z);
    }
}
