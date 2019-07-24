using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mk_Follow : MonoBehaviour
{

    public GameObject entity;
    public GameObject placeHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entity == null)
        {
            entity = placeHolder;
        }

        Vector3 pos = new Vector3(entity.transform.position.x, entity.transform.position.y + 2, entity.transform.position.z);
        transform.position = pos;

    }
}
