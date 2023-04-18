using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bost : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float spawnTime;
    private SpawnManager spawnManager;
   
    public abstract void Bosst(PlayerStats player);

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
            Destroy(gameObject);
            PlayerStats player = other.GetComponent<PlayerStats>();
            Bosst(player);
            spawnManager.RespawnCooldown();
        }
    }
}
