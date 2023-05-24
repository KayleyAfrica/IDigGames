using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Chest;
    public TMP_Text AvailBalance;
    public int MoneyAvail = 100;
    public bool IsShopOpen { get; private set; }
    public bool shopActive = true;

    void Start()
    {

    }

    void Update()
    {
        AvailBalance.text = "$" + MoneyAvail.ToString();
        UpdateShopActiveState();
    }

    public void ToChest()
    {
        Chest.SetActive(true);
        Shop.SetActive(false);
        IsShopOpen = false;
        shopActive = false;
    }

    public void RefundItem(int refundAmount)
    {
        if (shopActive)
        {
            MoneyAvail += refundAmount;
            AvailBalance.text = MoneyAvail.ToString();
        }
        else
        {
            Debug.Log("Shop is not active. Cannot refund item.");
        }
    }

    public void RefundItemChest(int refundAmount)
    {
        if (shopActive)
        {
            MoneyAvail += refundAmount;
            AvailBalance.text = MoneyAvail.ToString();
        }
        else
        {
            Debug.Log("Shop is not active. Cannot refund item.");
        }
    }

    private void UpdateShopActiveState()
    {
        shopActive = Shop.activeSelf; // Update the shopActive bool based on the active state of the Shop game object
    }
}
