using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform destination;
    GameObject puck;

    public void Awake()
    {
        puck = GameObject.FindGameObjectWithTag("Puck");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            if(Vector2.Distance(puck.transform.position, transform.position)> 0.7f)
            {
                puck.transform.position = destination.transform.position;
            }
            
        }
    }
}
