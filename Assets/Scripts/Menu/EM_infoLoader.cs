using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EM_infoLoader : MonoBehaviour
{

    private GameObject MapConfig;
    private GameObject SimResults;

    private Text Text_Map;
    private Text Text_EttQtty;
    private Text Text_SimTime;
    private Text Text_SimSpeed;
    private Text Text_FoodSpeed;
    private Text Text_FoodQtty;
    private Text Text_BornQtty;
    private Text Text_DeathQtty;
    private Text Text_partnerHunger;
    private Text Text_partnerRange;
    private Text Text_foodRange;
    private Text Text_wanderTime;
    private Text Text_wanderRadius;
    private Text Text_speed;

    // Start is called before the first frame update
    void Start()
    {
        MapConfig = GameObject.Find("MapConfig");
        SimResults = GameObject.Find("SimResults");

        Text_Map = GameObject.Find("Text_Map").GetComponent<Text>();
        Text_EttQtty = GameObject.Find("Text_EttQtty").GetComponent<Text>();
        Text_SimTime = GameObject.Find("Text_SimTime").GetComponent<Text>();
        Text_SimSpeed = GameObject.Find("Text_SimSpeed").GetComponent<Text>();
        Text_FoodSpeed = GameObject.Find("Text_FoodSpeed").GetComponent<Text>();
        Text_FoodQtty = GameObject.Find("Text_FoodQtty").GetComponent<Text>();
        Text_BornQtty = GameObject.Find("Text_BornQtty").GetComponent<Text>();
        Text_DeathQtty = GameObject.Find("Text_DeathQtty").GetComponent<Text>();
        Text_partnerHunger = GameObject.Find("Text_partnerHunger").GetComponent<Text>();
        Text_partnerRange = GameObject.Find("Text_partnerRange").GetComponent<Text>();
        Text_foodRange = GameObject.Find("Text_foodRange").GetComponent<Text>();
        Text_wanderTime = GameObject.Find("Text_wanderTime").GetComponent<Text>();
        Text_wanderRadius = GameObject.Find("Text_wanderRadius").GetComponent<Text>();
        Text_speed = GameObject.Find("Text_speed").GetComponent<Text>();

        if (MapConfig != null)
        {
            Text_Map.text = MapConfig.GetComponent<MM_MapConfig>().MapName;
            Text_EttQtty.text = MapConfig.GetComponent<MM_MapConfig>().EttQtty.ToString();
            Text_SimTime.text = MapConfig.GetComponent<MM_MapConfig>().SimTime.ToString();
            Text_SimSpeed.text = "x" + MapConfig.GetComponent<MM_MapConfig>().SimSpeed.ToString();
            Text_FoodSpeed.text = MapConfig.GetComponent<MM_MapConfig>().FoodSpeed.ToString();
            Text_FoodQtty.text = MapConfig.GetComponent<MM_MapConfig>().FoodQtty.ToString();
        }

        if (SimResults != null)
        {
            Text_BornQtty.text = SimResults.GetComponent<SimResults>().BornQtty.ToString();
            Text_DeathQtty.text = SimResults.GetComponent<SimResults>().DeathQtty.ToString();
            Text_partnerHunger.text = SimResults.GetComponent<SimResults>().partnerHungerAvg.ToString();
            Text_partnerRange.text = SimResults.GetComponent<SimResults>().partnerRangeAvg.ToString();
            Text_foodRange.text = SimResults.GetComponent<SimResults>().foodRangeAvg.ToString();
            Text_wanderTime.text = SimResults.GetComponent<SimResults>().wanderTimeAvg.ToString();
            Text_wanderRadius.text = SimResults.GetComponent<SimResults>().wanderRadiusAvg.ToString();
            Text_speed.text = SimResults.GetComponent<SimResults>().speedAvg.ToString();
        }
    }
}
