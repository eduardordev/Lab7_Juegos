using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent enemy;

    public GameObject waypoint;
    public List<GameObject> WayPList;
    void Start()
    {

        enemy = GetComponent<NavMeshAgent>();

        foreach (Transform child in waypoint.transform)
        {
            WayPList.Add(child.gameObject);
        }

        enemy.SetDestination(WayPList[Random.Range(0, WayPList.Count - 1)].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.remainingDistance < 0.2f)
            enemy.SetDestination(WayPList[Random.Range(0, WayPList.Count - 1)].transform.position);

    }
}