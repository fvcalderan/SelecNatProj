using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewbornGenerator : MonoBehaviour
{
    private GameObject newbornObj = null;
    public GameObject entityPrefab;
    public float MapRadius = 18;

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
