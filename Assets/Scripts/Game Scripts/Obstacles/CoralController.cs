using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private Color[] colors;
    private Color randomColor;

    private void Start()
    {
        colors = new Color[6]
        {
            Color.blue,
            Color.cyan,
            Color.green,
            Color.red,
            Color.magenta,
            Color.yellow
        };

        randomColor = colors[Random.Range(0, 5)];
    }

    private void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        spriteRenderer.color = Color.Lerp(Color.white, randomColor, Mathf.PingPong(Time.time, 1));
    }
}
