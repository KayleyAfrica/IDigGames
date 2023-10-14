using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabbableObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabbableObject)
    {
        this.grabbableObject = grabbableObject;
        rb.useGravity = false;
    }

    public void Drop()
    {
        this.grabbableObject = null;
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(grabbableObject != null)
        {
            float speed = 10f;
            Vector3 newPos = Vector3.Lerp(transform.position, grabbableObject.position, Time.deltaTime * speed);
            rb.MovePosition(newPos);
        }
    }
}
