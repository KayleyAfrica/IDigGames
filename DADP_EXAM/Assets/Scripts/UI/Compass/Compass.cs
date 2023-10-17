using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform player;
    private Vector3 direction;

    void Update()
    {
        direction.z = player.transform.eulerAngles.y;
        transform.localEulerAngles = direction;
    }
}
