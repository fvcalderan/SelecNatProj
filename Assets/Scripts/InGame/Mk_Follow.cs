using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mk_Follow : MonoBehaviour
{

    public GameObject entity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(entity.transform.position.x, entity.transform.position.y + 2, entity.transform.position.z);
        transform.position = pos;
    }
}
