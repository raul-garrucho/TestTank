using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Escudo que proteje de un hit al jugador
public class Shield : MonoBehaviour
{
    public float rotationSpeed;
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
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.hp++;
            spawnManager.activeBoost = false;
            Destroy(gameObject);
        }
    }
}
