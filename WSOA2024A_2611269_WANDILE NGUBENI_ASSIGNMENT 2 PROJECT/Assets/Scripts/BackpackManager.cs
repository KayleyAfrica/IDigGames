using UnityEngine;
using TMPro;

public class BackpackManager : MonoBehaviour
{
    public TMP_Text maxSpaceTxt;
    public int MaxSpace = 100;
    public int CurrentUsedSpace = 0;
    public TMP_Text usedSpace;
    public GameObject slotsChest;
    private ChestManager chestManager;
    private ShopManager shopManager;
    public TMP_Text updateCostTxt;
    private int upgradeCost = 20;

    private void Start()
    {
        chestManager = FindObjectOfType<ChestManager>();
        shopManager = FindObjectOfType<ShopManager>();
    }

    void Update()
    {
        usedSpace.text = CurrentUsedSpace.ToString();
        maxSpaceTxt.text = MaxSpace.ToString();
        updateCostTxt.text = "Upgrade $" + upgradeCost.ToString();
    }

    public bool CanAddItem(int weight)
    {
        return CurrentUsedSpace + weight <= MaxSpace;
    }

    public void AddItem(int weight)
    {
        CurrentUsedSpace += weight;
        usedSpace.text = CurrentUsedSpace.ToString();
    }

    public void RemoveItem(int weight)
    {
        if (CurrentUsedSpace >= weight)
        {
            CurrentUsedSpace -= weight;
        }
        else
        {
            CurrentUsedSpace = 0;
        }

        usedSpace.text = CurrentUsedSpace.ToString();
    }


    public void OnUpgrade()
    {
        if(shopManager.MoneyAvail >= upgradeCost)
        {
            MaxSpace += 50;
            shopManager.MoneyAvail -= upgradeCost;
        }
    }

}
