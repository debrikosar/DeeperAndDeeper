using UnityEngine;
using UnityEngine.UI;

public class FadePanelController : MonoBehaviour
{
    [SerializeField] private Image image;

    // Update is called once per frame
    void Update()
    {
        ChangeAlfaChannel();
    }

    private void ChangeAlfaChannel()
    {
        float deep = Camera.main.transform.position.y;
        if (deep < 0 && image.color.a < 0.8)
        {
            deep /= -50;
            var tempColor = image.color;
            tempColor.a = deep;
            image.color = tempColor;
        }
    }
}
