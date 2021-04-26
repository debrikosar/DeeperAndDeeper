using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirBarScript : MonoBehaviour
{
    public bool isUnderwater;
    private RectTransform rectTransform;

    private const int airBarSize = -300;

    public float airDepletionSpeed = 1f;
    public float airDepletionAmount = 10f;

    public float SharkDepletionAmount = 30f;

    private SaveManagerScript saveManagerScript;


    void Start()
    {
        saveManagerScript = GameObject.FindWithTag("SaveManager").GetComponent<SaveManagerScript>();
        rectTransform = gameObject.GetComponent<RectTransform>();

        PlayerController.OnTouchSurface += RestoreAirAtSurfacen;
        PlayerController.OnUnderWater += CancellSurfaceAirRestoration;
        PlayerController.OnPickUpOxygenBuff += RestoreAir;

        StartCoroutine(DepleteAir());
    }

    public void RestoreAirAtSurfacen(float whyDoINeedThis)
    {
        isUnderwater = false;
        RestoreAir();
    }

    public void CancellSurfaceAirRestoration(bool isUnderwater) => this.isUnderwater = isUnderwater;

    public void RestoreAir()
    {
        rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);
    }

    IEnumerator DepleteAir()
    {
        while (rectTransform.offsetMax.x > airBarSize)
        {   if(isUnderwater)
                rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x - airDepletionAmount, rectTransform.offsetMax.y);

            yield return new WaitForSeconds(airDepletionSpeed);
        }

        saveManagerScript.SaveFieldsIntoStatistic();
        SceneManager.LoadScene("GameEndScene"); 

        StopCoroutine(DepleteAir());
    }

    public void SharkAirDepletion()
    {
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x - SharkDepletionAmount, rectTransform.offsetMax.y);
    }
}
