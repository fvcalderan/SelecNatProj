using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Time_Elapsed : MonoBehaviour
{

    private Text Text_Elapsed;
    float timer = 0.0f;
    float maxTime;

    private GameObject MapConfig;
    private GameObject SimResults;

    private Text Text_BornQtty;
    private Text Text_DeathQtty;

    // Start is called before the first frame update
    void Start()
    {
        MapConfig = GameObject.Find("MapConfig");
        SimResults = GameObject.Find("SimResults");

        maxTime = MapConfig.GetComponent<MM_MapConfig>().SimTime;

        Text_Elapsed = GameObject.Find("Text_Elapsed").GetComponent<Text>();

        Text_BornQtty = GameObject.Find("Text_BirthCount").GetComponent<Text>();
        Text_DeathQtty = GameObject.Find("Text_DeathCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag("Entity");
        if (timer <= maxTime && entities.Length != 0 )
        {
            timer += Time.deltaTime;
            Text_Elapsed.text = timer.ToString("0") + " s";
        } else
        {
            doEndOfSimStuff();
        }
    }

    void doEndOfSimStuff()
    {
        DontDestroyOnLoad(SimResults.gameObject);
        SimResults.GetComponent<SimResults>().BornQtty = int.Parse(Text_BornQtty.text);
        SimResults.GetComponent<SimResults>().DeathQtty = int.Parse(Text_DeathQtty.text);

        GameObject[] entities = GameObject.FindGameObjectsWithTag("Entity");
        float foodRangeSum = 0;
        float partnerRangeSum = 0;
        float partnerHungerSum = 0;
        float wanderRadiusSum = 0;
        float wanderTimeSum = 0;
        float speedSum = 0;

        foreach (GameObject entity in entities)
        {
            foodRangeSum += entity.GetComponent<Ett_Move>().foodRange;
            partnerRangeSum += entity.GetComponent<Ett_Move>().partnerRange;
            partnerHungerSum += entity.GetComponent<Ett_Move>().partnerHunger;
            wanderRadiusSum += entity.GetComponent<Ett_Move>().wanderRadius;
            wanderTimeSum += entity.GetComponent<Ett_Move>().wanderTimer;
            speedSum += entity.GetComponent<NavMeshAgent>().speed;
        }

        float numOfEntities = entities.Length;

        SimResults.GetComponent<SimResults>().foodRangeAvg = foodRangeSum / numOfEntities;
        SimResults.GetComponent<SimResults>().partnerRangeAvg = partnerRangeSum / numOfEntities;
        SimResults.GetComponent<SimResults>().partnerHungerAvg = partnerHungerSum / numOfEntities;
        SimResults.GetComponent<SimResults>().wanderRadiusAvg = wanderRadiusSum / numOfEntities;
        SimResults.GetComponent<SimResults>().wanderTimeAvg = wanderTimeSum / numOfEntities;
        SimResults.GetComponent<SimResults>().speedAvg = speedSum / numOfEntities;

        SceneManager.LoadScene(1);

    }
}
