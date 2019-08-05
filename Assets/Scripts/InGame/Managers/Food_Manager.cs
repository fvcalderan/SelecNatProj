using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Food_Manager : MonoBehaviour
{

    public GameObject entityPrefab;
    private GameObject camSelect;

    public float SpawnRadius = 18;
    
    public float foodSpawnTime;
    public float foodHungerTime;

    public int foodMaxQuantity = 0;

    [HideInInspector]
    public int foodQuantity = 0;

    public int DeathCount = 0;
    private float foodTimer;
    private float hungerTimer;
    
    private GameObject[] entities;

    private GameObject MapConfig;


    // Start is called before the first frame update
    void Start()
    {
        MapConfig = GameObject.Find("MapConfig");

        foodSpawnTime = MapConfig.GetComponent<MM_MapConfig>().FoodSpeed;
        foodMaxQuantity = MapConfig.GetComponent<MM_MapConfig>().FoodQtty;

        camSelect = GameObject.Find("CameraSelector");
    }

    // Update is called once per frame
    void Update()
    {
        foodTimer += Time.deltaTime;
        if (foodTimer >= foodSpawnTime && foodQuantity < foodMaxQuantity)
        {
            Vector3 position;

      
            position = RandomNavmeshLocation(SpawnRadius);


            Instantiate(entityPrefab, position, Quaternion.identity);
            foodQuantity++;

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
                    if (camSelect.GetComponent<Cam_Select>().marker.GetComponent<Mk_Follow>().entity == entity)
                    {
                        camSelect.GetComponent<Cam_Select>().mainCamera.SetActive(true);
                        camSelect.GetComponent<Cam_Select>().mainCameraSelected = true;
                    }
                    Destroy(entity);
                    DeathCount++;
                }
            }

            hungerTimer = 0;
        }
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
