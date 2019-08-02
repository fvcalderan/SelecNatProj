using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.UI;

public class Ett_Generate : MonoBehaviour
{

    public GameObject entityPrefab;
    public int numOfEntities;
    public float spawnRadius;

    private GameObject newEntity;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfEntities; i++)
        {
            Vector3 position = RandomNavmeshLocation(spawnRadius);
            newEntity = Instantiate(entityPrefab, position, Quaternion.identity);
            newEntity.GetComponent<Ett_Move>().foodRange = Random.Range(5.0f, 20.0f);
            newEntity.GetComponent<Ett_Move>().partnerRange = Random.Range(5.0f, 20.0f);
            newEntity.GetComponent<Ett_Move>().partnerHunger = Random.Range(12, 30);
            newEntity.GetComponent<Ett_Move>().wanderRadius = Random.Range(5.0f, 20.0f);
            newEntity.GetComponent<Ett_Move>().wanderTimer = Random.Range(0.25f, 3.5f);
            newEntity.GetComponent<NavMeshAgent>().speed = Random.Range(1.0f, 6.0f);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}