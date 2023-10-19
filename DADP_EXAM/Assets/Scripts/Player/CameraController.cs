using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply movement to the Camera (empty GameObject)
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        // Get mouse input for horizontal rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Rotate the camera only around the Y-axis based on mouse input
        transform.Rotate(Vector3.up, mouseX);
    }
}




