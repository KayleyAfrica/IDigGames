using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestManager : MonoBehaviour
{
    public ShopManager shopManager;
    public TMP_Text usedSpaceTxt;
    public int usedSpace = 0;
    public TMP_Text maxSpaceTxt;
    public int maxSpace = 100;
    public GameObject Shop;
    public GameObject Chest;
    public bool IsChestActive { get; private set; }
    public bool shopActive = false;


    private void Start()
    {
        IsChestActive = false;
        shopManager = FindObjectOfType<ShopManager>();
    }

    void Update()
    {
        UpdateShopActiveState();

    }

    public void ToShop()
    {
        Chest.SetActive(false);
        Shop.SetActive(true);
        IsChestActive = false; 
        shopActive = true;
    }


    private void UpdateShopActiveState()
    {
        shopActive = Shop.activeSelf;
    }

    public bool CanAddItem(int weightMass)
    {
        return true;
    }
}
