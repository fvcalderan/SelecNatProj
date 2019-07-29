using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ett_OffMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    public bool linking;
    public float origSpeed;
    public float linkSpeed;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        origSpeed = agent.speed;
        linking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.isOnOffMeshLink && linking == false)
        {
            linking = true;
            agent.speed = linkSpeed;
        }
        else if (agent.isOnNavMesh && linking == true)
        {
            linking = false;
            agent.velocity = Vector3.zero;
            agent.speed = origSpeed;
        }
    }
}
