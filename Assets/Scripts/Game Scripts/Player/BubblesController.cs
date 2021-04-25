using System.Collections;
using UnityEngine;

public class BubblesController : MonoBehaviour
{
    [SerializeField] ParticleSystem bubbleParticles;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerController.OnUnderWater += BubblesSwitch;
    }

    private void BubblesSwitch(bool underWater)
    {
        if (underWater)
            StartCoroutine(WaitTillUnderWater());
        else
            bubbleParticles.Stop();
    }

    IEnumerator WaitTillUnderWater()
    {
        yield return new WaitForSeconds(1f);
        bubbleParticles.Play();
    }

    private void OnDestroy()
    {
        PlayerController.OnUnderWater -= BubblesSwitch;
    }
}
