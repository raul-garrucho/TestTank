using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float shootForce;
    [SerializeField] private string shooterId;


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
            CactusManager.Instance.DestroyCactus(other.transform.gameObject);
        }
        rb.velocity = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
        PoolManager.Instance.AddToQueue(this);
    }

    public void SetBullet(Vector3 firepoint, Quaternion direction)
    {
        transform.position = firepoint;
        transform.rotation = direction;
        gameObject.SetActive(true);
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
