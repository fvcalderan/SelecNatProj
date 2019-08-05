using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_AvgColor : MonoBehaviour
{
    private GameObject SimResults;

    // Start is called before the first frame update
    void Start()
    {
        SimResults = GameObject.Find("SimResults");

        if (SimResults != null)
        {
            float wanderRadius = Scale(5.0f, 20.0f, 0.0f, 1.0f, SimResults.GetComponent<SimResults>().wanderRadiusAvg);
            float wanderTime = Scale(0.25f, 3.5f, 0.0f, 1.0f, SimResults.GetComponent<SimResults>().wanderTimeAvg);
            float foodRange = Scale(5.0f, 20.0f, 0.0f, 1.0f, SimResults.GetComponent<SimResults>().foodRangeAvg);
            float partnerRange = Scale(5.0f, 20.0f, 0.0f, 1.0f, SimResults.GetComponent<SimResults>().partnerRangeAvg);
            float partnerHunger = Scale(12.0f, 30.0f, 0.0f, 1.0f, SimResults.GetComponent<SimResults>().partnerHungerAvg);
            float speed = Scale(1.0f, 6.0f, 0.0f, 1.0f, SimResults.GetComponent<SimResults>().speedAvg);

            Color bodyColor = new Color(wanderRadius, foodRange, partnerRange, 1.0f);
            Color armsColor = new Color(wanderTime, speed, partnerHunger, 1.0f);

            GetComponent<Renderer>().material.color = bodyColor;

            transform.GetChild(1).GetComponent<Renderer>().material.color = armsColor;
            transform.GetChild(2).GetComponent<Renderer>().material.color = armsColor;
        }

    }

    public float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }
}
