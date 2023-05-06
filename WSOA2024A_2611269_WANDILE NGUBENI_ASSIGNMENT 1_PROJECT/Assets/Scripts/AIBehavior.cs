using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 StartingPosition;

    public Rigidbody2D Puck;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPos;
    private bool isFirstTimeInOpponetsHalf = true;
    private float offsetXFromTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartingPosition = rb.position;

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.x,
                                     PlayerBoundaryHolder.GetChild(1).position.x,
                                     PlayerBoundaryHolder.GetChild(2).position.y,
                                     PlayerBoundaryHolder.GetChild(3).position.y);

        playerBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.x,
                                     PuckBoundaryHolder.GetChild(1).position.x,
                                     PuckBoundaryHolder.GetChild(2).position.y,
                                     PuckBoundaryHolder.GetChild(3).position.y);

    }

    private void FixedUpdate()
    {
        if (!PuckScript.WasGoal)
        {
            float movementSpeed;

            if (Puck.position.y < puckBoundary.Down)
            {
                if (isFirstTimeInOpponetsHalf)
                {
                    isFirstTimeInOpponetsHalf = false;
                    offsetXFromTarget = Random.Range(-1f, 1f);
                }
                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.03f);
                targetPos = new Vector2(Mathf.Clamp(Puck.position.x + offsetXFromTarget, playerBoundary.Down, playerBoundary.Up),
                                        StartingPosition.y);
            }
            else
            {
                isFirstTimeInOpponetsHalf = true;

                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPos = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Down, playerBoundary.Up),
                                       Mathf.Clamp(Puck.position.y, playerBoundary.Left, playerBoundary.Right));
            }

            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPos, movementSpeed * Time.fixedDeltaTime));

        }
    }

    public void ResetPosition()
    {
        rb.position = StartingPosition;
    }

}
