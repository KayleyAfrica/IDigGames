using UnityEngine;

public class Scroll : Interactable
{
    public GameObject Icon;
    public int noOfScrolls = 0;
    protected override void Interact()
    {
        gameObject.SetActive(false);
        if (!Icon.activeSelf)
        {
            Icon.SetActive(false);
            noOfScrolls++;
        }
    }
}
