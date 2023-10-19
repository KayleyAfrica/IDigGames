using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply movement to the Rigidbody
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
}
