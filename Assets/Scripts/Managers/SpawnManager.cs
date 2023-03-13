using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] boostPerfabsList;
    public Transform spawnTransform;
    public int selectedBoost;
    public float respawBoostTime,actualRespawnBoostTime;
    public bool activeBoost;
    private void Start()
    {
        activeBoost = false;
    }
    private void Update()
    {
        if (!activeBoost)
        {
            actualRespawnBoostTime += Time.deltaTime;
            if(actualRespawnBoostTime >= respawBoostTime)
            {
                selectedBoost = Random.Range(0,boostPerfabsList.Length);
                Instantiate(boostPerfabsList[selectedBoost],spawnTransform);
                actualRespawnBoostTime = 0;
                activeBoost = true;
            }
        }
    }
}
