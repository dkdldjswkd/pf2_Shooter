﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{

    NavMeshAgent pathfinder;
    Transform target;

    public void Start()
    {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdatePath()
    {
        float reFreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(reFreshRate);
        }
    }
}
