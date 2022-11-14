/**
 * Author: Aidan Pohl
 * Created: Nov 14, 2022
 * 
 * Descritpion: Animation Controller for the Chick
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]

public class AnimationControllerChick : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    public float runVelocity = 0.1f;
    public string animationRunParameter;
    public string animationSpeedParameter;
    private float maxSpeed;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        maxSpeed = navMeshAgent.speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(animationSpeedParameter, navMeshAgent.velocity.magnitude / maxSpeed);
    }
}
