using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName ="ShopItems", menuName ="ScriptableObjects/NewShopItems", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public int Cost;
    public int Quantity;
    public int Weight;
    public Sprite ArtWork;

}
