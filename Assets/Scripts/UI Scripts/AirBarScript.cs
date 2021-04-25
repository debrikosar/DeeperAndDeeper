using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirBarScript : MonoBehaviour
{
    public bool isUnderwater;
    private RectTransform rectTransform;

    private const int airBarSize = -300;

    private SaveManagerScript saveManagerScript;

    void Start()
    {
        saveManagerScript = GameObject.FindWithTag("SaveManager").GetComponent<SaveManagerScript>();
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

        saveManagerScript.SaveFieldsIntoStatistic();
        SceneManager.LoadScene("GameEndScene"); 

        StopCoroutine(DepleteAir());
    }
}
