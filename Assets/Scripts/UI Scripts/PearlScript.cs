using TMPro;
using UnityEngine;

public class PearlScript : MonoBehaviour
{
    private TextMeshProUGUI pearlCountText;
    public int pearlCount;

    private void Awake()
    {
        PlayerController.OnPickUpPearl += PearlPickedUp;
        ShopController.OnBuyAnythingPearl += SpendPearl;
    }

    private void Start()
    {
        pearlCountText = this.gameObject.GetComponent<TextMeshProUGUI>();
        pearlCountText.text = pearlCount.ToString();
    }

    public void PearlPickedUp()
    {
        pearlCount++;
        pearlCountText.text = pearlCount.ToString();
    }

    public void SpendPearl(int amount)
    {
        pearlCount -= amount;
        pearlCountText.text = pearlCount.ToString();
    }

    private void OnDestroy()
    {
        PlayerController.OnPickUpPearl -= PearlPickedUp;
        ShopController.OnBuyAnythingPearl -= SpendPearl;
    }
}
