using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Movimiento y daño de la bala
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float shootForce;
    public string shooterId;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*shootForce,ForceMode.Impulse);
    }
    public void setId(string id)
    {
        shooterId =  id;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.hp--;
            playerStats.attackerId = shooterId;
        }
        if (other.tag == "Cactus") other.GetComponent<Cactus>().cactusDestroy();
        Destroy(gameObject);
    }
}
