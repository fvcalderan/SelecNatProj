using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_Color : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float wanderRadius = Scale(5.0f, 20.0f, 0.0f, 1.0f, GetComponent<Ett_Move>().wanderRadius);
        float wanderTime = Scale(0.25f, 3.5f, 0.0f, 1.0f, GetComponent<Ett_Move>().wanderTimer);
        float foodRange = Scale(5.0f, 20.0f, 0.0f, 1.0f, GetComponent<Ett_Move>().foodRange);
        float partnerRange = Scale(5.0f, 20.0f, 0.0f, 1.0f, GetComponent<Ett_Move>().partnerRange);
        float partnerHunger = Scale(12.0f, 30.0f, 0.0f, 1.0f, GetComponent<Ett_Move>().partnerHunger);

        Color bodyColor = new Color(wanderRadius, foodRange, partnerRange, 1.0f);
        Color armsColor = new Color(wanderTime, 0, partnerHunger, 1.0f);

        GetComponent<Renderer>().material.color = bodyColor;

        transform.GetChild(1).GetComponent<Renderer>().material.color = armsColor;
        transform.GetChild(2).GetComponent<Renderer>().material.color = armsColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

}
