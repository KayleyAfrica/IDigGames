using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float mouseSens = 100f;
    public float xRot = 0f;
    private Transform player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
