using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] float restrictX;
    [SerializeField] float restrictYup;
    [SerializeField] float restrictYdown;

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -restrictX, restrictX),
                                         Mathf.Clamp(player.position.y, restrictYdown, restrictYup),
                                         transform.position.z);
    }
}
