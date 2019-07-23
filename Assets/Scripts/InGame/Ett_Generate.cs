using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Ett_Generate : MonoBehaviour 
{

    public GameObject entityPrefab;
    public int numOfEntities;

    //public Text Hover_Text_Food;
    //public GameObject Hover_Marker;


    // Start is called before the first frame update
    void Start()
    {
        //entityPrefab.GetComponent<Ett_Hover>().Text_Food = Hover_Text_Food;
        //entityPrefab.GetComponent<Ett_Hover>().Marker = Hover_Marker;

        for (int i = 0; i < numOfEntities; i++)
        {
            Vector3 position = new Vector3(Random.Range(-13.0f, 13.0f), 1.0f, Random.Range(-13.0f, 13.0f));
            Instantiate(entityPrefab, position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
