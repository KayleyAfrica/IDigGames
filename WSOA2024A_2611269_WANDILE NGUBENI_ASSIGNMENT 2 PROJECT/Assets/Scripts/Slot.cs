using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject itemPrefab; 

    private void Start()
    {
        Instantiate(itemPrefab, transform.position, Quaternion.identity, transform);

        Debug.Log("Item instantiated on start!");
    }
}
