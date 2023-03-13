using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public bool destroyCactus;
    private SinglePlayerManager singlePlayerManager;

    private void Awake()
    {
        singlePlayerManager = transform.GetComponentInParent<SinglePlayerManager>();
    }
    private void Update()
    {
        if (destroyCactus)
        {
            singlePlayerManager.distroyedCactusNumber++;
            singlePlayerManager.numberCactus--;
            Destroy(gameObject);
        }
    }
}
