using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalPrefab;
    public GameObject portalPrefab1;
    public GameObject portalPrefab2;
    public GameObject portalPrefab3;
    public float minY;
    public float maxY;
    public float spawnTime = 20f;
    public float minInterval = 15f;
    public float maxInterval = 30f;

    private float timer;
    private bool portalActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Disable portal on start
        portalPrefab.SetActive(false);
        timer = Random.Range(minInterval, maxInterval);
        portalPrefab1.SetActive(false);
        timer = Random.Range(minInterval, maxInterval);
        portalPrefab2.SetActive(false);
        timer = Random.Range(minInterval, maxInterval);
        portalPrefab3.SetActive(false);
        timer = Random.Range(minInterval, maxInterval);

    }

    // Update is called once per frame
    void Update()
    {
        if (!portalActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnPortal();
                portalActive = true;
                timer = spawnTime;
            }
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DestroyPortal();
                portalActive = false;
                timer = Random.Range(minInterval, maxInterval);
            }
        }
    }

    void SpawnPortal()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(portalPrefab, spawnPosition, Quaternion.identity);
        portalPrefab.SetActive(true);

        float y1 = Random.Range(minY, maxY);
        Vector3 spawnPosition1 = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(portalPrefab1, spawnPosition1, Quaternion.identity);
        portalPrefab1.SetActive(true);

        float y2 = Random.Range(minY, maxY);
        Vector3 spawnPosition2 = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(portalPrefab2, spawnPosition2, Quaternion.identity);
        portalPrefab2.SetActive(true);

        float y3 = Random.Range(minY, maxY);
        Vector3 spawnPosition3 = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(portalPrefab3, spawnPosition3, Quaternion.identity);
        portalPrefab3.SetActive(true);

    }

    void DestroyPortal()
    {
       
        portalPrefab.SetActive(false);
        portalPrefab1.SetActive(false);
        portalPrefab2.SetActive(false);
        portalPrefab3.SetActive(false);


    }
}
