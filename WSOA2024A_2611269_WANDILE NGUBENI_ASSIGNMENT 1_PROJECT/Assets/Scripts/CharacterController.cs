using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

    bool wasJustClicked = true;
    bool canMove;
    

    Rigidbody2D rb;

    Vector2 StartingPosition;



    Boundary playerBoundary;

    public Transform BoundaryHolder;


    Collider2D playerCollider;


    

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartingPosition = rb.position;
        playerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.x,
                                     BoundaryHolder.GetChild(1).position.x,
                                     BoundaryHolder.GetChild(2).position.y,
                                     BoundaryHolder.GetChild(3).position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(!PuckScript.WasGoal)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (wasJustClicked)
                {
                    wasJustClicked = false;

                    if (playerCollider.OverlapPoint(mousePos))
                    {
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }

                if (canMove)
                {
                    Vector2 clampedmousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Down
                                        , playerBoundary.Up),
                                        Mathf.Clamp(mousePos.y, playerBoundary.Left, playerBoundary.Right));
                    rb.MovePosition(clampedmousePos);
                }


            }
            else
            {
                wasJustClicked = true;
            }
        }
    }
    public void ResetPosition()
    {
        rb.position = StartingPosition;
    }

}