using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndInstantiate : MonoBehaviour
{
    public GameObject itemPrefab; // The prefab to instantiate

    public void OnMouseDown()
    {
        Transform slotTransform = FindSlotTransform();
        if (slotTransform != null)
        {
            Instantiate(itemPrefab, slotTransform.position, slotTransform.rotation);
        }
    }

    private Transform FindSlotTransform()
    {
        // Logic to find the slot transform dynamically
        // You can implement your own logic here based on your scene hierarchy or tag-based search

        // Example: Finding the slot by tag
        GameObject slot = GameObject.FindGameObjectWithTag("Slot");
        if (slot != null)
        {
            return slot.transform;
        }

        // Return null if no slot is found
        return null;
    }
}
