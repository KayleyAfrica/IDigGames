using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Ref to Char controller
    public CharacterController controller;
    //move vars
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
        climbing,
    }

    // Ladder vars
    bool isClimbing;
    float Range = 1f;
    public Transform detectLadder;

    void StateHandler()
    {
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            state = movementState.sprint;
            speed = sprintSpeed;
        }

        else if (isGrounded && state != movementState.climbing)
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

        if(state != movementState.climbing)
        {
            // Move
            var H = Input.GetAxis("Horizontal");
            var V = Input.GetAxis("Vertical");

            Vector3 move = transform.right * H + transform.forward * V;
            controller.Move(move * Time.deltaTime * speed);
          }

        ClimbLadder();

        if (state == movementState.climbing && isClimbing)
        {
            var climb = Input.GetAxis("Vertical");
            Vector3 climbUp = transform.up * climb;
            controller.Move(climbUp * speed * Time.deltaTime);
        }
    }

    void ClimbLadder()
    {
        Ray ray = new Ray(detectLadder.position, detectLadder.forward);
        if(Physics.Raycast(ray, out RaycastHit hit, Range))
        {
            if(hit.transform.TryGetComponent(out Ladder ladder))
            {
                velocity.y = 0;
                isGrounded = true;
                isClimbing = true;
                print("Ladder Detected");
                state = movementState.climbing; 
            }
        }

        else
        {
            isGrounded = true;
            isClimbing = false;
            state = movementState.walk;
        }
    }
}
