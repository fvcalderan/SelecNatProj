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

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfEntities; i++)
        {
            Vector3 position = RandomNavmeshLocation(spawnRadius);
            Instantiate(entityPrefab, position, Quaternion.identity);
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