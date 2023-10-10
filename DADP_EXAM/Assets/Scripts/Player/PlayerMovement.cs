using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float speed;
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpHeight;

    // Jump vars
    private float gravity = -9.81f;
    private float distance = .4f;
    public bool isGrounded;
    private Vector3 velocity;
    public Transform groundCheck;
    public LayerMask mask;

    public movementState state;
    public enum movementState
    {
        walk,
        sprint,
    }
    void StateHandler()
    {
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            state = movementState.sprint;
            speed = sprintSpeed;
        }

        else if (isGrounded)
        {
            state = movementState.walk;
            speed = walkSpeed;
        }
    }


    void Update()
    {
        StateHandler();
        isGrounded = Physics.CheckSphere(groundCheck.position, distance, mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Move
        var H = Input.GetAxis("Horizontal");
        var V = Input.GetAxis("Vertical");

        Vector3 move = transform.right * H + transform.forward * V;
        controller.Move(move * Time.deltaTime * speed);
    }
}
