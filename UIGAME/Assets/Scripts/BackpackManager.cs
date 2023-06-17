using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class BackpackManager : MonoBehaviour
{
    public MusicAndSFx musicAndSFx;
    public ShopItemSO[] shopItemSO;
    public GameObject[] shopItemsGO;
    public ShopTemplate[] shopItems;
    public Button[] myButton;
    public Button[] myButton2;
    public ShopManager shopManager;
    public ChestManager chestManager;


    //Texts && integers
    public TMP_Text SpaceTxt;
    public int Space = 0;
    public TMP_Text maxSpace;
    public int MaxSpace = 100;
    public int Upgrade = 50;


    // Start is called before the first frame update
    void Start()
    {
        //this should always start at 0(quantity)
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopItemSO[i].Quantity = 0;

        }
        maxSpace.text = "/"+MaxSpace.ToString();
        SpaceTxt.text = "Space:" + Space.ToString();
        LoadItems();
        CanSell();
        CanMove();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnUpgrade()
    {
        if(shopManager.coins >= Upgrade)
        {
            shopManager.coins -= Upgrade;
            MaxSpace += 50;
            maxSpace.text = "/"+MaxSpace.ToString();
            // i want to play the song on upgrade
            musicAndSFx.UpgradeSFx.clip = musicAndSFx.UpgradeSpace;
            musicAndSFx.UpgradeSFx.Play();
        }
    }

    public void SetActiveItem(int itemIndex)
    {
        if (itemIndex >= 0 && itemIndex < shopItemsGO.Length)
        {

            shopItemsGO[itemIndex].SetActive(true);
        }
        shopItemSO[itemIndex].Quantity++;
        shopItems[itemIndex].QuantityTxt.text = shopItemSO[itemIndex].Quantity.ToString();

        
    }

    

    public void CanSell()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (shopManager.coins >= shopItemSO[i].Cost && shopItemSO[i].Quantity >= 0)
                myButton[i].interactable = true;
            else
                
                myButton[i].interactable = false;
            
        }
    }

    public void SellItems(int ButtonNo)
    {
        if (shopItemSO[ButtonNo].Quantity >= 0)
        {
            Space -= shopManager.shopItemSO[ButtonNo].Weight;
            SpaceTxt.text = "Space:" + Space.ToString();
            shopManager.shopItemSO[ButtonNo].Quantity++;
            shopManager.shopItems[ButtonNo].QuantityTxt.text = shopManager.shopItemSO[ButtonNo].Quantity.ToString();
            shopItemSO[ButtonNo].Quantity--;
            shopItems[ButtonNo].QuantityTxt.text = shopItemSO[ButtonNo].Quantity.ToString();
            shopManager.coins += shopItemSO[ButtonNo].Cost;
            shopManager.coinTxt.text = "Money:$" + shopManager.coins.ToString();

            CanSell();

            if (shopItemSO[ButtonNo].Quantity == 0)
            {
                shopItemsGO[ButtonNo].SetActive(false);
            }
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

    public void MoveToChest(int ButtonNo)
    {
        if (shopItemSO[ButtonNo].Quantity >= 0 && chestManager.Space + shopManager.shopItemSO[ButtonNo].Weight <= chestManager.MaxSpace && Space - shopManager.shopItemSO[ButtonNo].Weight >= 0)
        {
            chestManager.Space += shopManager.shopItemSO[ButtonNo].Weight;
            chestManager.SpaceTxt.text = "Space:" + chestManager.Space.ToString();
            Space -= shopManager.shopItemSO[ButtonNo].Weight;
            SpaceTxt.text = "Space:" + Space.ToString();
            chestManager.shopItemSO[ButtonNo].Quantity++;
            chestManager.shopItems[ButtonNo].QuantityTxt.text = chestManager.shopItemSO[ButtonNo].Quantity.ToString();
            shopItemSO[ButtonNo].Quantity--;
            shopItems[ButtonNo].QuantityTxt.text = shopItemSO[ButtonNo].Quantity.ToString();
            chestManager.SetActiveItem(ButtonNo);
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
