using UnityEngine;
using UnityEngine.AI;

public class ControlTraffic : MonoBehaviour
{
    public GameObject path;
    public Transform[] wayPoints;
    public NavMeshAgent agent;
    float minDistance = 10
        ;

    int index = 0;

    private void Start()
    {
        wayPoints = new Transform[path.transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = path.transform.GetChild(i);
        }
    }
    void Update()
    {
        Roam();
    }

    void Roam()
    {
        if(Vector3.Distance(transform.position, wayPoints[index].position) < minDistance)
        {
            if(index > 0 && index < wayPoints.Length - 1)
            {
                index+=1;
            }
            else
            {
                index = 0;
            }
        }

        agent.SetDestination(wayPoints[index].position);
    }
}
