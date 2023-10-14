using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool isActive;


    void Awake()
    {
        inventoryPanel.SetActive(true);
    }


    void Update()
    {
        isActive = !isActive;
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(isActive);    
        }
    }
}