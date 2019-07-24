using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Manager : MonoBehaviour
{

    public GameObject entityPrefab;
    public float protectRadius;
    
    public float foodSpawnTime;
    public float foodHungerTime;

    private float foodTimer;
    private float hungerTimer;

    private GameObject[] entities;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodTimer += Time.deltaTime;
        if (foodTimer >= foodSpawnTime)
        {
            Vector3 position;

            do
            {
                position = new Vector3(Random.Range(-13.0f, 13.0f), 0.0f, Random.Range(-13.0f, 13.0f));


            } while (!ValidPosition(position, protectRadius));

            Instantiate(entityPrefab, position, Quaternion.identity);

            foodTimer = 0;
        }

        hungerTimer += Time.deltaTime;
        if (hungerTimer >= foodHungerTime)
        {
            entities = GameObject.FindGameObjectsWithTag("Entity");

            foreach (GameObject entity in entities)
            {
                entity.GetComponent<Ett_Move>().food_qtty--;
                if (entity.GetComponent<Ett_Move>().food_qtty==0)
                {

                    Destroy(entity);
                }
            }

            hungerTimer = 0;
        }
    }

    private bool ValidPosition(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "Obstacle" || hitColliders[i].gameObject.tag == "Entity")
            {
                return false;
            }
            i++;
        }
        return true;
    }

}
