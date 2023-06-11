using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ChestManager : MonoBehaviour
{
    //Buy and sell buttons
    public GameObject MainButton;
    public GameObject MainButton1;
    public GameObject MainButton2;
    public GameObject MainButton3;
    public GameObject MainButton4;
    public GameObject MainButton5;
    public GameObject MainButton6;
    public GameObject MainButton7;
    //Chest and Backpack buttons
    public GameObject moveToChest;
    public GameObject moveToChest1;
    public GameObject moveToChest2;
    public GameObject moveToChest3;
    public GameObject moveToChest4;
    public GameObject moveToChest5;
    public GameObject moveToChest6;
    public GameObject moveToChest7;

    public GameObject Chest;
    public GameObject Shop;
    public ShopItemSO[] shopItemSO;
    public GameObject[] shopItemsGO;
    public ShopTemplate[] shopItems;
    public Button[] myButton;
    public GameObject upgradeButton;

    //Texts && integers
    public TMP_Text SpaceTxt;
    public int Space = 0;
    public TMP_Text maxSpace;
    public int MaxSpace = 100;
    public TMP_Text AfterUpgrade;
    public int Upgrade = 10;

    public BackpackManager backpackManager;
    public ShopManager shopManager;

    // Start is called before the first frame update
    void Start()
    {
        //this should always start at 0(quantity)
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopItemSO[i].Quantity = 0;

        }
        maxSpace.text = "/" + MaxSpace.ToString();
        SpaceTxt.text = "Space:" + Space.ToString();
        LoadItems();
        CanMove();
    }

    // Update is called once per frame
    void Update()
    {
        backpackManager.SpaceTxt.text = "Space:" + backpackManager.Space.ToString();
    }

    public void OnUpgrade()
    {
        if (shopManager.coins >= Upgrade)
        {
            shopManager.coins -= Upgrade;
            MaxSpace += 1000;
            AfterUpgrade.text = "INFINITE++";
            // I will also destroy these gameObjects so that i can display the infinite text 
            Destroy(maxSpace.gameObject);
            Destroy(SpaceTxt.gameObject);
            // this means you can only upgrade once because after upgrade the space will be infinite therefore the 
            //upgrade button would not no longer be necessary 
            Destroy(upgradeButton.gameObject);
        }
    }
    public void ToShop()
    {
        Shop.SetActive(true);
        Chest.SetActive(false);

        //Sell Buttons
        MainButton.SetActive(true);
        MainButton1.SetActive(true);
        MainButton2.SetActive(true);
        MainButton3.SetActive(true);
        MainButton4.SetActive(true);
        MainButton5.SetActive(true);
        MainButton6.SetActive(true);
        MainButton7.SetActive(true);
        //move items to chest button
        moveToChest.SetActive(false);
        moveToChest1.SetActive(false);
        moveToChest2.SetActive(false);
        moveToChest3.SetActive(false);
        moveToChest4.SetActive(false);
        moveToChest5.SetActive(false);
        moveToChest6.SetActive(false);
        moveToChest7.SetActive(false);
    }

    public void SetActiveItem(int itemIndex)
    {
        if (itemIndex >= 0 && itemIndex < shopItemsGO.Length )
        {

            shopItemsGO[itemIndex].SetActive(true);

        }
        
    }

    public void CanMove()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {


            if (shopItemSO[i].Quantity >= 0 && MaxSpace >= Space)
            {
                myButton[i].interactable = true;
            }
            else
            {
                myButton[i].interactable = false;
            }
        }
    }

    public void MoveToBackpack(int ButtonNo)
    {
        if (shopItemSO[ButtonNo].Quantity >= 0 && backpackManager.Space + shopManager.shopItemSO[ButtonNo].Weight <= backpackManager.MaxSpace)
        {
           
            Space -= shopManager.shopItemSO[ButtonNo].Weight;
            SpaceTxt.text = "Space:" + Space.ToString();
            shopItemSO[ButtonNo].Quantity--;
            shopItems[ButtonNo].QuantityTxt.text = shopItemSO[ButtonNo].Quantity.ToString();
            backpackManager.Space += shopManager.shopItemSO[ButtonNo].Weight;
            backpackManager.SpaceTxt.text = "Space:" + backpackManager.Space.ToString();
            backpackManager.SetActiveItem(ButtonNo);
            CanMove();
            if (shopItemSO[ButtonNo].Quantity <= 0)
            {
                shopItemsGO[ButtonNo].SetActive(false);
            }
        }
    }

    public void LoadItems()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopItems[i].nameTxt.text = shopItemSO[i].itemName;
            shopItems[i].CostTxt.text = shopItemSO[i].Cost.ToString();
            shopItems[i].QuantityTxt.text = shopItemSO[i].Quantity.ToString();
            shopItems[i].artWork.sprite = shopItemSO[i].ArtWork;
        }
    }
}
