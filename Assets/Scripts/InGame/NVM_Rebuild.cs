using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NVM_Rebuild : MonoBehaviour
{

    public NavMeshSurface surf;

    // Update is called once per frame
    void Update()
    {
        surf.BuildNavMesh();
    }
}
