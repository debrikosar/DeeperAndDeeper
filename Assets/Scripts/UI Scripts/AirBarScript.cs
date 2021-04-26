using System;
using System.Collections;
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

    public static event Action OnOxygenDepletion;

    void Awake()
    {
        PlayerController.OnTouchSurface += RestoreAirAtSurfacen;
        PlayerController.OnUnderWater += CancellSurfaceAirRestoration;
        PlayerController.OnPickUpOxygenBuff += RestoreAir;
        PlayerController.OnCollisionShark += SharkAirDepletion;
        ShopController.OnBuyOxygen += ReduceAirConsumption;
    }

    void Start()
    {
        isUnderwater = false;
        saveManagerScript = GameObject.FindWithTag("SaveManager").GetComponent<SaveManagerScript>();
        rectTransform = gameObject.GetComponent<RectTransform>();
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

        OnOxygenDepletion?.Invoke();
        saveManagerScript.SaveFieldsIntoStatistic();
        SceneManager.LoadScene("GameEndScene"); 

        StopCoroutine(DepleteAir());
    }

    public void SharkAirDepletion()
    {
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x - SharkDepletionAmount, rectTransform.offsetMax.y);
    }

    private void ReduceAirConsumption()
    {
        if(airDepletionAmount > 2f)
            airDepletionAmount--;
    }

    private void OnDestroy()
    {
        PlayerController.OnTouchSurface -= RestoreAirAtSurfacen;
        PlayerController.OnUnderWater -= CancellSurfaceAirRestoration;
        PlayerController.OnPickUpOxygenBuff -= RestoreAir;
        PlayerController.OnCollisionShark -= SharkAirDepletion;
        ShopController.OnBuyOxygen -= ReduceAirConsumption;
    }
}
