using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float shootForce;
    [SerializeField] private string shooterId;
    [SerializeField]
    private PoolManager poolManager = null;

    private void Awake()
    {
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
    public void setId(string id)
    {
        shooterId = id;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.Dmg();
            playerStats.attackerId = shooterId;
        }
        if (other.tag == "Cactus")
        {
            FindObjectOfType<CactusManager>().DestroyCactus(other.transform.gameObject);
        }

        //TODO deshabilitarlo

        poolManager.AddToQueue(this);
    }
}
