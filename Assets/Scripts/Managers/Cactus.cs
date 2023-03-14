using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public bool destroyCactus;
    private PlayerManager singlePlayerManager;

    private void Awake()
    {
        singlePlayerManager = transform.GetComponentInParent<PlayerManager>();
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
