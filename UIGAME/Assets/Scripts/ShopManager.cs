using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
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

    public MusicAndSFx musicAndSFx;
    public GameObject Chest;
    public GameObject Shop;
    public BackpackManager backpackManager;
    public ShopItemSO[] shopItemSO;
    public GameObject[] shopItemsGO;
    public ShopTemplate[] shopItems;
    public Button[] myButton;

    public TMP_Text coinTxt;
    public int coins = 100;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopItemsGO[i].SetActive(true);
            // THIS SHOULD ENSURE THE ITEM QUANTITY ALWAYS START AT 20
            shopItemSO[i].Quantity = 20;
        }
                   
        coinTxt.text = "Money:$"+coins.ToString();
        LoadItems();
        
    }

    // Update is called once per frame
    void Update()
    {
        coinTxt.text = "Money:$" + coins.ToString();
        CanPurchase();
    }
    
    public void ToChest()
    {
        Shop.SetActive(false);
        Chest.SetActive(true);
        //Sell Buttons
        MainButton.SetActive(false);
        MainButton1.SetActive(false);
        MainButton2.SetActive(false);
        MainButton3.SetActive(false);
        MainButton4.SetActive(false);
        MainButton5.SetActive(false);
        MainButton6.SetActive(false);   
        MainButton7.SetActive(false);

        moveToChest.SetActive(true);
        moveToChest1.SetActive(true);
        moveToChest2.SetActive(true);  
        moveToChest3.SetActive(true);
        moveToChest4.SetActive(true);
        moveToChest5.SetActive(true);
        moveToChest6.SetActive(true);
        moveToChest7.SetActive(true);
    }

    public void CanPurchase()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (coins >= shopItemSO[i].Cost && shopItemSO[i].Quantity > 0 && backpackManager.Space + shopItemSO[i].Weight <= backpackManager.MaxSpace)
            {
                myButton[i].interactable = true;
            }
            else
            {
                myButton[i].interactable = false;
            }
        }
    }



    public void PurchaseItems(int ButtonNo)
    {
        musicAndSFx.SFx.clip = musicAndSFx.OnBuy;
        musicAndSFx.SFx.Play();
        if (coins >= shopItemSO[ButtonNo].Cost && shopItemSO[ButtonNo].Quantity >= 0 && backpackManager.MaxSpace >= backpackManager.Space)
        {
           
            coins -= shopItemSO[ButtonNo].Cost;
            coinTxt.text = "Money:$" + coins.ToString();
            shopItemSO[ButtonNo].Quantity--;
            shopItems[ButtonNo].QuantityTxt.text = shopItemSO[ButtonNo].Quantity.ToString();
            backpackManager.Space += shopItemSO[ButtonNo].Weight;
            backpackManager.SpaceTxt.text = "Space:" + backpackManager.Space.ToString();

            CanPurchase();
    
            backpackManager.SetActiveItem(ButtonNo);
        }
    }

    public void LoadItems()
    {
        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopItems[i].nameTxt.text = shopItemSO[i].itemName;
            shopItems[i].CostTxt.text = shopItemSO[i].Cost.ToString();
            shopItems[i].QuantityTxt.text = shopItemSO[i].Quantity.ToString();
            shopItems[i].artWork.sprite = shopItemSO[i].ArtWork;
        }
    }
}
