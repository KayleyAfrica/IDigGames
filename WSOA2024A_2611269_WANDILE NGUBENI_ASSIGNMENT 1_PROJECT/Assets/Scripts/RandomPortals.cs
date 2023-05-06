using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPortals : MonoBehaviour
{
    private Vector2 randomPos;
    public float xminRange = 1f;
    public float xmaxRange = 1f;
    public float yminRange = 1f;
    public float ymaxRange = 1f;


    void Start()
    {
        float xPosition = Random.Range(0 - xminRange, xminRange);
        float yPosition = Random.Range(0 - yminRange, yminRange);

        randomPos = new Vector2(0, yPosition);
        transform.position = randomPos;
    }

    
}
