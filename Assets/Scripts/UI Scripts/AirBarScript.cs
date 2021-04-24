using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBarScript : MonoBehaviour
{
    public bool isUnderwater;
    private RectTransform rectTransform;

    private const int airBarSize = -300;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(DepleteAir());
    }

    public void RestoreAir()
    {
        rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);
    }

    IEnumerator DepleteAir()
    {
        while (rectTransform.offsetMax.x > airBarSize)
        {   if(isUnderwater)
                rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x - 10, rectTransform.offsetMax.y);

            yield return new WaitForSeconds(1);
        }

        StopCoroutine(DepleteAir());
    }
}
