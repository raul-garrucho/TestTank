using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// spawn de los diferenrtes boosts
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] boostPerfabsList;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private float respawnBoostTime;
 
    private void Start()
    {
        StartCoroutine(CountTime());
    }
    public void RespawnCooldown()
    {
        StartCoroutine(CountTime());
    }
    IEnumerator CountTime()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        bool emptySpawn = true;
        float currentTime = 0;
        while (emptySpawn)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= respawnBoostTime)
            {
                emptySpawn = false;
                currentTime = 0;
                int selectedBoost = Random.Range(0, boostPerfabsList.Length);
                Instantiate(boostPerfabsList[selectedBoost], spawnTransform);
            }
                yield return wait;
        }
    }
}
