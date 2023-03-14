using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Boost de velocidad
public class VelocityBoost : MonoBehaviour
{
    public float rotationSpeed;
    public float boostVelocity,maxTimeOfBoost;
    private SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = transform.GetComponentInParent<SpawnManager>();
    }
    private void Update()
    {
        transform.Rotate(transform.up * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovemetn playerMovemetn = other.GetComponent<PlayerMovemetn>();
            playerMovemetn.speedModifier = boostVelocity;
            playerMovemetn.maxtime = maxTimeOfBoost;
            playerMovemetn.boostActive = true;
            spawnManager.activeBoost = false;
            Destroy(gameObject);
        }
    }
}
