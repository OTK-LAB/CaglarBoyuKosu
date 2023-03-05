using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour
{
    
    CharacterController karakter;

    public Transform hedef;
    
    NavMeshAgent Agent;

    public float mesafe;  

    void Start()
    {
        hedef = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        karakter = GetComponent<CharacterController>();
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        mesafe = Vector3.Distance(transform.position, hedef.position);

        Agent.destination = hedef.position;

        if(mesafe <= 5)
        {
            Agent.enabled = true;
        }
        else
        {
            Agent.enabled = false;
        }
    }
}
