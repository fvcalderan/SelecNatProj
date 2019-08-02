using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChrome : MonoBehaviour
{
    public float every;
    float colorstep;
    Color[] colors = new Color[7];
    int i;
    Color lerpedColor = Color.red;
    private int initColorNum;

    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.red;
        colors[1] = Color.magenta;
        colors[2] = Color.blue;
        colors[3] = Color.cyan;
        colors[4] = Color.green;
        colors[5] = Color.yellow;
        colors[6] = Color.red;
        initColorNum = Random.Range(0, 6);
        lerpedColor = colors[initColorNum];
        i = initColorNum;
    }


    // Update is called once per frame
    void Update()
    {

        if (colorstep < every)
        {
            lerpedColor = Color.Lerp(colors[i], colors[i + 1], colorstep);
            GetComponent<Renderer>().material.color = lerpedColor;
            colorstep += 0.01f;
        }
        else
        {
            colorstep = 0;
            if (i < (colors.Length - 2))
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }
}
