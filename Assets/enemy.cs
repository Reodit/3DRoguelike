using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    //monster states
    private float maxHealth;
    private float health;
    private float power;
    private float speed;
    private float knockback;
    private float xp;
    
    
    //follow target v
    private NavMeshAgent nav;
    public Transform target;
    private void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.Find("Capsule").transform;
    }

    void Update()
    {
        transform.LookAt(target);
        nav.destination = target.position;
    }
}
