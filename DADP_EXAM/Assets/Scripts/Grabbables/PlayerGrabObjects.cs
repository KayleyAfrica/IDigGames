using UnityEngine;

public class PlayerGrabObjects : MonoBehaviour
{
    public Camera cam;
    public Transform grabPoint;
    private GrabbableObject grabbableObject;
    float Range = 3f;
    public LayerMask excludePlayer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (grabbableObject == null)
            {
                Ray ray = new Ray(cam.transform.position, cam.transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hit, Range, excludePlayer))
                {
                    if (hit.transform.TryGetComponent(out grabbableObject))
                    {
                        grabbableObject.Grab(grabPoint);
                    }
                }

                
            }

            else
            {
                grabbableObject.Drop();
                grabbableObject = null;
            }
        }
    }
}
