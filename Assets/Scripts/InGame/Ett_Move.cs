using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ett_Move : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public float foodRadius;

    public int food_qtty;

    private NavMeshAgent agent;
    private float timer;
    private GameObject foodObj;

    // Use this for initialization
    void OnEnable()
    {
        food_qtty = 0;
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        foodObj = CheckForFood(this.gameObject.transform.position, foodRadius);
        if (foodObj==null)
        {
            timer += Time.deltaTime;
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
        else
        {
            agent.SetDestination(foodObj.transform.position);
            if (Vector3.Distance(this.gameObject.transform.position, foodObj.transform.position)<=1.5f)
            {
                food_qtty++;
                Destroy(foodObj.gameObject);
            }
        }
        
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    public GameObject CheckForFood(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag=="Food")
            {
                return hitColliders[i].gameObject; 
            }
            i++;
        }
        return null;
    }
}
