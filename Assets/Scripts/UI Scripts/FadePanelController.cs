using UnityEngine;
using UnityEngine.UI;

public class FadePanelController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        ChangeAlfaChannel();
    }

    private void ChangeAlfaChannel()
    {
        float deep = Camera.main.transform.position.y;
        if (deep < 0)
        {
            deep /= -100;
            var tempColor = spriteRenderer.color;
            tempColor.a = deep;
            spriteRenderer.color = tempColor;
        }
    }
}
