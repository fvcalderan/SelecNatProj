using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirthDeath_Counter : MonoBehaviour
{
    private GameObject ReproductionManager;
    private GameObject FoodManager;
    private Text Text_BirthCount;

    private Text Text_DeathCount;
    // Start is called before the first frame update
    void Start()
    {
        Text_BirthCount = GameObject.Find("Text_BirthCount").GetComponent<Text>();
        Text_DeathCount = GameObject.Find("Text_DeathCount").GetComponent<Text>();
        ReproductionManager = GameObject.Find("ReproductionManager");
        FoodManager =  GameObject.Find("FoodManager");
    }

    // Update is called once per frame
    void Update()
    {
        Text_BirthCount.text = ReproductionManager.GetComponent<NewbornGenerator>().BirthCount.ToString();
        Text_DeathCount.text = FoodManager.GetComponent<Food_Manager>().DeathCount.ToString();
    }
}
