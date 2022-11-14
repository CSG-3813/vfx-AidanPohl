/**
 * Author: Aidan Pohl
 * Made: Nov, 14, 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent thisAgent;
    public Transform destination;
    private void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisAgent.SetDestination(destination.position); //updates where the agent wants to go;
    }
}
