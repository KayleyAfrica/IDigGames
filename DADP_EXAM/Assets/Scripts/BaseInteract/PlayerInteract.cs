using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    private PlayerUI playerUI;
    public LayerMask mask;
    public float Range = 10f;
    void Start()
    {
        cam = GetComponent<Camera>();   
        playerUI = GetComponent<PlayerUI>();    
    }

    void Update()
    {
        playerUI.UpdateTxt(string.Empty);   
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Range))
        {
            if(hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUI.UpdateTxt(interactable.promptMessage);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
