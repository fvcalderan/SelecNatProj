using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_MapConfig : MonoBehaviour
{
    [HideInInspector]
    public string MapName;
    [HideInInspector]
    public int EttQtty;
    [HideInInspector]
    public float SimTime;
    [HideInInspector]
    public int SimSpeed;
    [HideInInspector]
    public float FoodSpeed;
    [HideInInspector]
    public int FoodQtty;

    // Start is called before the first frame update
    void Start()
    {
        //Set defaults for testing or if something goes terribly wrong
        MapName = "DummyMap";
        EttQtty = 10;
        SimTime = 10000.0f;
        SimSpeed = 1;
        FoodSpeed = 0.3f;
        FoodQtty = 20;
    }
}
