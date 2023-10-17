using UnityEngine;
using TMPro;

public class Scroll : Interactable
{
    public GameObject Icon;
    public TMP_Text numberofSrollsTxt;
    public int noOfScrolls = 0;

    private void Update()
    {
        numberofSrollsTxt.text = noOfScrolls.ToString();
    }
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
