using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool isActive;

    public Animator anim;

    void Start()
    {
        
    }


    void Update()
    {
        isActive = !isActive;
        if(Input.GetKeyDown(KeyCode.I))
        {
            anim.SetBool("isOpen", isActive);
            ///inventoryPanel.SetActive(isActive);    
        }
    }
}
