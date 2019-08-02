using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ett_Move : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public float foodRange;

    public int food_qtty;

    private NavMeshAgent agent;
    private float timer;

    [HideInInspector]
    public bool isLookingForPartner;
    [HideInInspector]
    public bool readyToReproduce = false;

    public float partnerRange = 3;

    [HideInInspector]
    public bool partnerFound = false;

    public int partnerHunger = 10;
    
    public int generation; 
    private GameObject foodObj;

    [HideInInspector]
    public GameObject partnerObj = null;
    [HideInInspector]
    public GameObject foodManager;

    public GameObject entityPrefab;

    public float boredTimeSet;
    private float boredTime = 0.0f;

    // Use this for initialization
    void OnEnable()
    {
        foodManager = GameObject.Find("FoodManager");
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {   
        if (food_qtty >= partnerHunger)
        {
            isLookingForPartner = true;
        }
        else
        {
            isLookingForPartner = false;
        }

        if (isLookingForPartner)
        {
            partnerObj = CheckForPartner(this.gameObject.transform.position, partnerRange);
            if (partnerObj != null)
            {
                partnerFound = true;
            }
            else
            {
                partnerFound = false;
            }
        }

        if (partnerFound && food_qtty >= partnerHunger)
        {


            agent.ResetPath();

            if (partnerObj != null && boredTime <= boredTimeSet)
            {
                boredTime += Time.deltaTime;
                agent.SetDestination(partnerObj.transform.position);
            }
            else
            {
                boredTime = 0.0f;
            }


            if (Vector3.Distance(this.gameObject.transform.position, partnerObj.transform.position) <= 1.5f)
            {
                readyToReproduce = true;
                boredTime = 0.0f;
            }

        }
        else
        {
            foodObj = CheckFoodDistance();

            if (foodObj == null)
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
                if (Vector3.Distance(this.gameObject.transform.position, foodObj.transform.position) <= 1.5f)
                {
                    food_qtty++;
                    Destroy(foodObj.gameObject);
                    foodManager.GetComponent<Food_Manager>().foodQuantity--;
                }
            }
        }

        if (!GetComponent<Ett_Stopped>().IsMoving)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
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

    public GameObject CheckForPartner(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.GetInstanceID() != this.gameObject.GetInstanceID() && hitColliders[i].gameObject.tag == "Entity" && hitColliders[i].gameObject.GetComponent<Ett_Move>().isLookingForPartner)
            {
                return hitColliders[i].gameObject;
            }
            i++;
        }

        return null;
    }
    public GameObject CheckFoodDistance()
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
 
        foreach (GameObject food in foods)
        {
            Vector3 diff = food.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance <= Mathf.Pow(foodRange,2))
            {
                closest = food;
                distance = curDistance;
            }
            
        }
        return closest;
    }
}