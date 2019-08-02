using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Scaler : MonoBehaviour
{

    public Text Text_Speed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x1";
        }
        if (Input.GetKeyDown("1"))
        {
            Time.timeScale = 2.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x2";
        }
        if (Input.GetKeyDown("2"))
        {
            Time.timeScale = 4.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x4";
        }
        if (Input.GetKeyDown("3"))
        {
            Time.timeScale = 8.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x8";
        }
        if (Input.GetKeyDown("4"))
        {
            Time.timeScale = 16.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x16";
        }
        if (Input.GetKeyDown("5"))
        {
            Time.timeScale = 32.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x32";
        }
        if (Input.GetKeyDown("6"))
        {
            Time.timeScale = 64.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x64";
        }

        //When using Unity Editor, the maximum timeScale possible is 100.0f.
        if (Input.GetKeyDown("7"))
        {
            Time.timeScale = 100.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x100";
        }


        /*
        if (Input.GetKeyDown("7"))
        {
            Time.timeScale = 128.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x128";
        }
        if (Input.GetKeyDown("8"))
        {
            Time.timeScale = 256.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x256";
        }
        if (Input.GetKeyDown("9"))
        {
            Time.timeScale = 512.0f;
            Time.fixedDeltaTime = Time.timeScale;
            Text_Speed.text = "x512";
        }
        */
    }
}
