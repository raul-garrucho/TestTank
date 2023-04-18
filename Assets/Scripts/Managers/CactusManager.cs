using Gameplayy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactusManager : MonoBehaviour
{
    [SerializeField] private GameObject cactusPrefab;
    [SerializeField] private int destroyedCactus;
    public static event Action <int> cactusDestroy; 
    private void Awake()
    {
        AddCactus();
        AddCactus();
        AddCactus();
        AddCactus();
        AddCactus();
    }

    private void AddCactus()
    {
        float xOffset = UnityEngine.Random.Range(75, -75);
        float zOffset = UnityEngine.Random.Range(75, -75);
        Vector3 ramdonPosition = transform.position + new Vector3(xOffset, 0, zOffset);
        Instantiate(cactusPrefab, ramdonPosition, Quaternion.identity, transform);

    }
    public void DestroyCactus(GameObject cactus)
    {
        Destroy(cactus);
        destroyedCactus++;
        AddCactus();
        cactusDestroy?.Invoke(destroyedCactus);
        if (destroyedCactus >= 20)
        {
            destroyedCactus = 0;
            Gameplay.Instance.ChangeToExit("");
        }
    }
}
