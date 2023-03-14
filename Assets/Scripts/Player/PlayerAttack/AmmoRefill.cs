using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Recarga la municion de los tanques
public class AmmoRefill : MonoBehaviour
{
    public float rotationSpeed;
    public int numberOfRefill;
    private SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = transform.GetComponentInParent<SpawnManager>();
    }
    private void Update()
    {
        transform.Rotate(transform.up*rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            playerAttack.amountOfAmmo = playerAttack.amountOfAmmo + numberOfRefill;
            spawnManager.activeBoost = false;
            Destroy(gameObject);
        }
    }
}
