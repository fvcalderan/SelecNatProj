using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewbornGenerator : MonoBehaviour
{
    private GameObject newbornObj = null;
    public GameObject entityPrefab;
    public float MapRadius = 18;

    public float tolerance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        GiveBirth(new Vector3(0.0f, 0.0f, 0.0f), MapRadius);
    }

    public void GiveBirth(Vector3 center, float radius)
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Entity" && hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj != null)
            {
                if (hitColliders[i].gameObject.tag == "Entity" && 
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.tag == "Entity"&&
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().readyToReproduce && 
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().readyToReproduce &&
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerObj.GetInstanceID() == hitColliders[i].gameObject.GetInstanceID()
                    )
                {
                    Vector3 position = 0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().transform.position + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().transform.position);
                    newbornObj = Instantiate(entityPrefab, position, Quaternion.identity);
                    Debug.Log("WELCOME DEAR NEWBORN");

                    hitColliders[i].gameObject.GetComponent<Ett_Move>().food_qtty -= Mathf.FloorToInt(hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerHunger * 0.7f);
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().food_qtty -= Mathf.FloorToInt(hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerHunger * 0.7f);

                    int newborn_food_qtty = Mathf.FloorToInt(0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().food_qtty + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().food_qtty));
                    newbornObj.GetComponent<Ett_Move>().food_qtty = newborn_food_qtty;

                    float newborn_foodRange = 0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().foodRange + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().foodRange);
                    newborn_foodRange += Random.Range(-1.0f*tolerance*newborn_foodRange,tolerance*newborn_foodRange);
                    newbornObj.GetComponent<Ett_Move>().foodRange = newborn_foodRange;

                    float newborn_partnerRange = 0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerRange + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerRange);
                    newborn_partnerRange += Random.Range(-1.0f*tolerance*newborn_partnerRange,tolerance*newborn_partnerRange);
                    newbornObj.GetComponent<Ett_Move>().partnerRange = newborn_partnerRange;

                    int newborn_partnerHunger = Mathf.FloorToInt(0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerHunger + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerHunger));
                    newborn_partnerHunger += Mathf.FloorToInt(Random.Range(-1*tolerance*newborn_partnerHunger,tolerance*newborn_partnerHunger));
                    newbornObj.GetComponent<Ett_Move>().partnerHunger = newborn_partnerHunger;

                    float newborn_wanderRadius = 0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().wanderRadius + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().wanderRadius);
                    newborn_wanderRadius += Random.Range(-1.0f*tolerance*newborn_wanderRadius,tolerance*newborn_wanderRadius);
                    newbornObj.GetComponent<Ett_Move>().wanderRadius = newborn_wanderRadius;

                    float newborn_wanderTimer = 0.5f*(hitColliders[i].gameObject.GetComponent<Ett_Move>().wanderTimer + hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().wanderTimer);
                    newborn_wanderTimer += Random.Range(-1.0f*tolerance*newborn_wanderTimer,tolerance*newborn_wanderTimer);
                    newbornObj.GetComponent<Ett_Move>().wanderTimer = newborn_wanderTimer;

                    

                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().isLookingForPartner = false;
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerFound = false;
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().readyToReproduce = false;

                    hitColliders[i].gameObject.GetComponent<Ett_Move>().isLookingForPartner = false;
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerFound = false;
                    hitColliders[i].gameObject.GetComponent<Ett_Move>().readyToReproduce  =false;
                }
            }
            
            i++;
        }
        
    }
}
