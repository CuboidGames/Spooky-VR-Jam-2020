﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.AI;

public class GroupInstantiator : MonoBehaviour
{
    [SerializeField]
    private int groupsCount;

    [SerializeField]
    private List<Transform> spawnPoints;

    [SerializeField]
    private GameObject groupPrefab;

    [SerializeField]
    private GameObject kidPrefab;

    [SerializeField]
    private int minKidsInGroup = 1;

    [SerializeField]
    private int maxKidsInGroup = 2;


    void Start()
    {
        InstantiateRandomGroups();
    }

    private void InstantiateRandomGroups()
    {
        var randomizedSpawnPoints = spawnPoints.Select(i => i).ToList();
        var spawnPointsCount = spawnPoints.Count();

        for (int i = 0, ii = Mathf.Min(groupsCount, spawnPointsCount); i < ii; i++) {
            int rIndex = Random.Range(0, spawnPointsCount - i);

            InstantiateGroup(randomizedSpawnPoints[rIndex]);
            randomizedSpawnPoints.RemoveAt(rIndex);
        }
    }

    private void InstantiateGroup(Transform parent)
    {
        GameObject groupInstance = Instantiate(groupPrefab, parent);
        KidsInstantiator kidInstantiator = groupInstance.GetComponent<KidsInstantiator>();
        GroupController groupController = groupInstance.GetComponent<GroupController>();


        kidInstantiator.groupSize = Random.Range(minKidsInGroup, maxKidsInGroup);
        kidInstantiator.kidPrefab = kidPrefab;
        kidInstantiator.InstantiateKids(groupController);

        groupController.GetGroupKids();
        groupController.GetNewTarget();
    }
}