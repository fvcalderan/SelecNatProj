using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ett_Generate : MonoBehaviour 
{

    public GameObject entityPrefab;
    public int numOfEntities;

    public float protectRadius;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfEntities; i++)
        {
            Vector3 position;
            
            do
            {
                position = new Vector3(Random.Range(-13.0f, 13.0f), 1.0f, Random.Range(-13.0f, 13.0f));
                

            }while(!ValidPosition(position, protectRadius));
            
            Instantiate(entityPrefab, position, Quaternion.identity);
            
            //entityPrefab.GetComponent<Ett_Pathfind>().Dest = GameObject.Find("Dest");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool ValidPosition(Vector3 center,float radius){

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag=="Obstacle")
            {
                return false; 
            }
            i++;
        }
        return true;


    }

    
}
