using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            if(hitColliders[i].gameObject.tag == "Entity" && hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj != null && hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.tag == "Entity" && hitColliders[i].gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerObj != null)
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
                    

                    bool[] randomize_attr =  new bool[6];
                    randomize_attr[0] = false;
                    randomize_attr[1] = false;
                    randomize_attr[2] = false;
                    randomize_attr[3] = false;
                    randomize_attr[4] = false;
                    randomize_attr[5] = false;

                    float random_number = Random.Range(0,100);
                    if(random_number <= 40)
                    {
                        //randomize_atrr contains 6 "false" values
                    }
                    else if(random_number<= 50)     
                    {
                        // RANDOMIZES 1 ATTRIBUTE   
                        int random_idx = Random.Range(0,6);
                        randomize_attr[random_idx] = true;
                    }
                    else if(random_number <=60)
                    {
                        // RANDOMIZES 2 ATTRIBUTES
                        int random_idx = Random.Range(0,6);
                        randomize_attr[random_idx] = true;
                        do
                        {
                            random_idx = Random.Range(0,6);
                        }while(randomize_attr[random_idx] == true);
                        randomize_attr[random_idx] = true;
                    }
                    else if(random_number <= 70)
                    {
                        // RANDOMIZES 3 ATTRIBUTES
                        int random_idx = Random.Range(0,6);
                        randomize_attr[random_idx] = true;

                        do
                        {
                            random_idx = Random.Range(0,6);
                        }while(randomize_attr[random_idx] == true);
                        randomize_attr[random_idx] = true;

                        do
                        {
                            random_idx = Random.Range(0,6);
                        }while(randomize_attr[random_idx] == true);
                        randomize_attr[random_idx] = true;
                    
                    }
                    else if(random_number <= 80)
                    {
                        // RANDOMIZES 4 ATTRIBUTES
                        int random_idx = Random.Range(0,6);
                        randomize_attr[random_idx] = true;

                        do
                        {
                            random_idx = Random.Range(0,6);
                        }while(randomize_attr[random_idx] == true);
                        randomize_attr[random_idx] = true;

                        do
                        {
                            random_idx = Random.Range(0,6);
                        }while(randomize_attr[random_idx] == true);
                        randomize_attr[random_idx] = true;

                        do
                        {
                            random_idx = Random.Range(0,6);
                        }while(randomize_attr[random_idx] == true);
                        randomize_attr[random_idx] = true;
                    
                    }
                    else if(random_number <= 90)
                    {
                        // RANDOMIZES 5 ATTRIBUTES
                        int random_idx = Random.Range(0,6);
                        for(int k=0;k<6;k++)
                        {
                            randomize_attr[k] = true;
                        }
                        randomize_attr[random_idx] = false;

                    }else{
                        // RANDOMIZES 6 ATTRIBUTES
                        for(int k=0;k<6;k++)
                        {
                            randomize_attr[k] = true;
                        }

                    }

                    SetNewbornAttributes(hitColliders[i],randomize_attr);
                    newbornObj.GetComponent<Ett_Move>().generation = 1 + Mathf.Max(hitColliders[i].GetComponent<Ett_Move>().generation, hitColliders[i].GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().generation);


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

    private void SetNewbornAttributes(Collider parent ,bool[] randomize)
    {
        // 0 : speed
        if(randomize[0] == true)
        {
            newbornObj.GetComponent<NavMeshAgent>().speed = Random.Range(1.0f,6.0f);
            Debug.Log("Random Speed");
        }
        else
        {
            float newborn_speed = 0.5f*(parent.gameObject.GetComponent<NavMeshAgent>().speed + parent.gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<NavMeshAgent>().speed);
            newborn_speed += Random.Range(-1.0f*tolerance*newborn_speed,tolerance*newborn_speed);
            newbornObj.GetComponent<NavMeshAgent>().speed = newborn_speed;
        }

        // 1 : foodRange
        if(randomize[1] == true)
        {
            newbornObj.GetComponent<Ett_Move>().foodRange = Random.Range(5.0f,20.0f);
            Debug.Log("Random foodRange");
        }
        else
        {
            float newborn_foodRange = 0.5f*(parent.gameObject.GetComponent<Ett_Move>().foodRange + parent.gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().foodRange);
            newborn_foodRange += Random.Range(-1.0f*tolerance*newborn_foodRange,tolerance*newborn_foodRange);
            newbornObj.GetComponent<Ett_Move>().foodRange = newborn_foodRange;            

        }

        // 2 : partnerRange
        if(randomize[2] == true)
        {
            newbornObj.GetComponent<Ett_Move>().partnerRange = Random.Range(5.0f,20.0f);
            Debug.Log("Random partnerRange");
        }
        else
        {
            float newborn_partnerRange = 0.5f*(parent.gameObject.GetComponent<Ett_Move>().partnerRange + parent.gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerRange);
            newborn_partnerRange += Random.Range(-1.0f*tolerance*newborn_partnerRange,tolerance*newborn_partnerRange);
            newbornObj.GetComponent<Ett_Move>().partnerRange = newborn_partnerRange;
        }

        // 3 : partnerHunger
        if(randomize[3] == true)
        {
            newbornObj.GetComponent<Ett_Move>().partnerHunger = Random.Range(12,30);
            Debug.Log("Random partnerHunger");
        }
        else
        {
            int newborn_partnerHunger = Mathf.FloorToInt(0.5f*(parent.gameObject.GetComponent<Ett_Move>().partnerHunger + parent.gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().partnerHunger));
            newborn_partnerHunger += Mathf.FloorToInt(Random.Range(-1*tolerance*newborn_partnerHunger,tolerance*newborn_partnerHunger));
            newbornObj.GetComponent<Ett_Move>().partnerHunger = newborn_partnerHunger;

        }

        // 4 : wanderRadius
        if(randomize[4] == true)
        {
            newbornObj.GetComponent<Ett_Move>().wanderRadius = Random.Range(5.0f,20.0f);
            Debug.Log("Random wanderRadius");
        }
        else
        {
            float newborn_wanderRadius = 0.5f*(parent.gameObject.GetComponent<Ett_Move>().wanderRadius + parent.gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().wanderRadius);
            newborn_wanderRadius += Random.Range(-1.0f*tolerance*newborn_wanderRadius,tolerance*newborn_wanderRadius);
            newbornObj.GetComponent<Ett_Move>().wanderRadius = newborn_wanderRadius;

        }

        // 5 : wanderTimer
        if(randomize[5] == true)
        {
            newbornObj.GetComponent<Ett_Move>().wanderTimer = Random.Range(0.25f, 3.5f);
            Debug.Log("Random wanderTimer");
        }
        else
        {
            float newborn_wanderTimer = 0.5f*(parent.gameObject.GetComponent<Ett_Move>().wanderTimer + parent.gameObject.GetComponent<Ett_Move>().partnerObj.GetComponent<Ett_Move>().wanderTimer);
            newborn_wanderTimer += Random.Range(-1.0f*tolerance*newborn_wanderTimer,tolerance*newborn_wanderTimer);
            newbornObj.GetComponent<Ett_Move>().wanderTimer = newborn_wanderTimer;

        }

    }

}
