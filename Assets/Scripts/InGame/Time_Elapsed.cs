﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Elapsed : MonoBehaviour
{

    private Text Text_Elapsed;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Text_Elapsed = GameObject.Find("Text_Elapsed").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Text_Elapsed.text = timer.ToString("0") + " s";
    }
}
