using UnityEngine;
using TMPro;

public class StrawberryScript : MonoBehaviour
{
    public Music music;
    private ShopManager shopManager;
    private BackpackManager backpackManager;
    public ChestManager chestManager;
    public GameObject itemPrefab;

    public TMP_Text costText;
    public int costPrice = 17;
    public TMP_Text weightText;
    public int weightMass = 10;

    public TMP_Text CostTxt;
    public TMP_Text AmountTxt;
    public TMP_Text noOfItemsText;
    public int Amount = 0;

    private GameObject instantiatedItem; // Reference to the instantiated item

    // Start is called before the first frame update
    void Start()
    {
        shopManager = GameObject.FindObjectOfType<ShopManager>();
        backpackManager = GameObject.FindObjectOfType<BackpackManager>();
        chestManager = GameObject.FindObjectOfType<ChestManager>();
        music = GameObject.FindObjectOfType<Music>();
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = "$"+costPrice.ToString();
        weightText.text = weightMass.ToString();
        noOfItemsText.text = Amount.ToString();
    }

    public void AddItemToBackpack()
    {
        music.inGame.clip = music.Sfx;
        music.inGame.Play();

        if (!shopManager.shopActive)
        {
            Debug.Log("Shop is not active. Cannot buy item.");
            return;
        }

        if (costPrice <= shopManager.MoneyAvail && backpackManager.CanAddItem(weightMass))
        {
            Transform slotParent = GameObject.Find("SlotsBackpack").transform;

            for (int i = 0; i < slotParent.childCount; i++)
            {
                Transform slotChild = slotParent.GetChild(i);

                if (slotChild.childCount > 0)
                {
                    StrawberryScript existingItemScript = slotChild.GetChild(0).GetComponent<StrawberryScript>();

                    if (existingItemScript != null && existingItemScript.costPrice == costPrice)
                    {
                        if (slotChild.GetChild(0) == gameObject.transform) // Check if the clicked item is in the backpack slot
                        {
                            existingItemScript.Amount--;
                            existingItemScript.noOfItemsText.text = existingItemScript.Amount.ToString();

                            if (existingItemScript.Amount == 0)
                            {
                                shopManager.MoneyAvail += costPrice;
                                shopManager.AvailBalance.text = shopManager.MoneyAvail.ToString();
                                backpackManager.RemoveItem(weightMass);
                                Destroy(slotChild.GetChild(0).gameObject);
                            }
                            else
                            {
                                shopManager.MoneyAvail += costPrice;
                                shopManager.AvailBalance.text = shopManager.MoneyAvail.ToString();
                                backpackManager.RemoveItem(weightMass);
                            }
                        }
                        else
                        {
                            existingItemScript.Amount++;
                            existingItemScript.noOfItemsText.text = existingItemScript.Amount.ToString();
                            shopManager.MoneyAvail -= costPrice;
                            shopManager.AvailBalance.text = shopManager.MoneyAvail.ToString();
                            backpackManager.AddItem(weightMass);
                        }

                        return;
                    }
                }
            }

            // Item does not already exist in backpack
            for (int i = 0; i < slotParent.childCount; i++)
            {
                Transform slotChild = slotParent.GetChild(i);

                if (slotChild.childCount == 0)
                {
                    instantiatedItem = Instantiate(itemPrefab, slotChild.position, Quaternion.identity, slotChild);

                    // Disabletext after instantiation
                    StrawberryScript itemScript = instantiatedItem.GetComponent<StrawberryScript>();
                    itemScript.DisableText();
                    itemScript.EnableText();


                    itemScript.Amount = 1;
                    itemScript.noOfItemsText.text = "1";

                    shopManager.MoneyAvail -= costPrice;
                    shopManager.AvailBalance.text = shopManager.MoneyAvail.ToString();

                    backpackManager.AddItem(weightMass);

                    return;
                }
            }
        }
    }

    public void ChestToBackpackAndViceVersa()
    {
        Transform backpackSlotParent = GameObject.Find("SlotsBackpack").transform;

        Transform chestSlotParent = GameObject.Find("SlotsChest").transform;

        bool isBackpackSlot = false;
        bool isChestSlot = false;

        foreach (Transform slotChild in backpackSlotParent)
        {
            if (slotChild.childCount > 0 && slotChild.GetChild(0).gameObject == gameObject)
            {
                isBackpackSlot = true;
                break;
            }
        }

        foreach (Transform slotChild in chestSlotParent)
        {
            if (slotChild.childCount > 0 && slotChild.GetChild(0).gameObject == gameObject)
            {
                isChestSlot = true;
                break;
            }
        }

        if (isBackpackSlot)
        {
            StrawberryScript itemScript = GetComponent<StrawberryScript>();

            int totalWeight = itemScript.weightMass * itemScript.Amount; // Calculate total weight of the item

            backpackManager.CurrentUsedSpace -= totalWeight; // Decrease currentUsedSpace based on the total weight
            backpackManager.CurrentUsedSpace = Mathf.Max(backpackManager.CurrentUsedSpace, 0); // Ensure the currentUsedSpace is at least 0
            backpackManager.usedSpace.text = backpackManager.CurrentUsedSpace.ToString();

            Debug.Log("Updated backpack currentUsedSpace: " + backpackManager.CurrentUsedSpace);

            for (int i = 0; i < chestSlotParent.childCount; i++)
            {
                Transform chestSlotChild = chestSlotParent.GetChild(i);

                if (chestSlotChild.childCount > 0)
                {
                    StrawberryScript existingItemScript = chestSlotChild.GetChild(0).GetComponent<StrawberryScript>();

                    if (existingItemScript != null && existingItemScript.costPrice == itemScript.costPrice)
                    {
                        existingItemScript.Amount += itemScript.Amount;
                        existingItemScript.noOfItemsText.text = existingItemScript.Amount.ToString();
                        backpackManager.CurrentUsedSpace += totalWeight; // Increase currentUsedSpace based on the total weight
                        backpackManager.usedSpace.text = backpackManager.CurrentUsedSpace.ToString();

                        Destroy(gameObject);
                        return;
                    }
                }
                else
                {
                    Transform itemTransform = transform;
                    itemTransform.SetParent(chestSlotChild);
                    itemTransform.localPosition = Vector3.zero;

                    chestManager.usedSpace += totalWeight;
                    chestManager.usedSpaceTxt.text = chestManager.usedSpace.ToString();

                    return;
                }
            }
        }
        else if (isChestSlot)
        {
            StrawberryScript itemScript = GetComponent<StrawberryScript>();

            int totalWeight = itemScript.weightMass * itemScript.Amount; // Calculate total weight of the item

            backpackManager.CurrentUsedSpace += totalWeight; // Increase currentUsedSpace based on the total weight
            backpackManager.usedSpace.text = backpackManager.CurrentUsedSpace.ToString();

            Debug.Log("Updated backpack currentUsedSpace: " + backpackManager.CurrentUsedSpace);

            for (int i = 0; i < backpackSlotParent.childCount; i++)
            {
                Transform backpackSlotChild = backpackSlotParent.GetChild(i);

                if (backpackSlotChild.childCount == 0)
                {
                    Transform itemTransform = transform;
                    itemTransform.SetParent(backpackSlotChild);
                    itemTransform.localPosition = Vector3.zero;



                    return;
                }
                else
                {
                    StrawberryScript existingItemScript = backpackSlotChild.GetChild(0).GetComponent<StrawberryScript>();

                    if (existingItemScript != null && existingItemScript.costPrice == itemScript.costPrice)
                    {
                        existingItemScript.Amount += itemScript.Amount;
                        existingItemScript.noOfItemsText.text = existingItemScript.Amount.ToString();
                        chestManager.usedSpace -= totalWeight;
                        chestManager.usedSpaceTxt.text = chestManager.usedSpace.ToString();
                        backpackManager.CurrentUsedSpace += totalWeight; // Increase currentUsedSpace based on the total weight
                        backpackManager.usedSpace.text = backpackManager.CurrentUsedSpace.ToString();

                        Destroy(gameObject);
                        return;
                    }
                }
            }
        }
    }



    // Disables the CostTxt and the Cost gameObjects
    public void DisableText()
    {
        CostTxt.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
    }

    // Enables the amount and ItemAmount gameObjects
    public void EnableText()
    {
        AmountTxt.gameObject.SetActive(true);
        noOfItemsText.gameObject.SetActive(true);
    }
}
