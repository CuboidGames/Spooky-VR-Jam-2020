using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetSelector : MonoBehaviour
{

    private GameObject[] houseEntrances;
    private NavMeshAgent agent;

    public Transform currentGoal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        houseEntrances = GameObject.FindGameObjectsWithTag("HouseEntrance");
        currentGoal = houseEntrances[Random.Range(0, houseEntrances.Length)].transform;

        agent.destination = currentGoal.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            agent.destination = transform.position;
        }
    }
}
