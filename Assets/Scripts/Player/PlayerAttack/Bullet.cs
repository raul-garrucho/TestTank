using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float shootForce;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(transform.forward*shootForce,ForceMode.Impulse);
    }
    private void Update()
    {
        transform.Rotate(transform.right * 0.25f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.hp--;
        }
        if (other.tag == "Cactus") other.GetComponent<Cactus>().destroyCactus = true;
        Destroy(gameObject);
    }
}
