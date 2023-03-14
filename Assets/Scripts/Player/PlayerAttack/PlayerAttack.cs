using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int amountOfAmmo;
    private InputManager inputManager;
    public float readytime, actualtime;
    public string shooterId;
 
    private void Awake()
    {
        inputManager = transform.GetComponent<InputManager>();
        amountOfAmmo = 10;
    }
    private void Update()
    {
       actualtime += Time.deltaTime;
       amountOfAmmo = Mathf.Clamp(amountOfAmmo, 0, 15);
       if (inputManager.shootButton&& actualtime>readytime) Shoot();
    }
    private void Shoot()
    {
        if (amountOfAmmo > 0)
        {
            Quaternion lookDirectio = Quaternion.LookRotation(transform.forward);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, lookDirectio);
            bullet.GetComponent<Bullet>().setId(shooterId);
            amountOfAmmo--;
            actualtime = 0;
        }
    }

}
