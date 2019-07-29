using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Float : MonoBehaviour
{

    public float speed = 5f;
    public float height = 0.5f;
    private float differ;

    void Start()
    {
        differ = Random.Range(-100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float newY = Mathf.Abs(Mathf.Sin(Time.time * speed + differ));
        transform.position = new Vector3(pos.x, newY * height, pos.z);
    }
}
