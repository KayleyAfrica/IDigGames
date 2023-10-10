using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text promptTxt;
    public void UpdateTxt(string prompt)
    {
        promptTxt.text = prompt;
    }
}
