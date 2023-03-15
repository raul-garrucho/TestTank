using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint,canon;
    public GameObject bulletPrefab;
    public int amountOfAmmo;
    private InputManager inputManager;
    public float rechargtime, actualRechargTime,rotationSpeed;
    public string shooterId;
    private float currentRotationX,currentRotationY;  
    private void Awake()
    {
        inputManager = transform.GetComponent<InputManager>();
        amountOfAmmo = 10;
    }
    private void Update()
    {
        actualRechargTime += Time.deltaTime;
        amountOfAmmo = Mathf.Clamp(amountOfAmmo, 0, 15);
        SetCurrentRotation();
        if (inputManager.shootButton&& actualRechargTime>rechargtime) Shoot();
    }
    private void Shoot()
    {
        if (amountOfAmmo > 0)
        {
            Quaternion lookDirectio = Quaternion.LookRotation(canon.forward);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, lookDirectio);
            bullet.GetComponent<Bullet>().setId(shooterId);
            amountOfAmmo--;
            actualRechargTime = 0;
        }
    }
    void SetCurrentRotation()
    {
        float roty = currentRotationY + inputManager.rotationCanonInput.y * rotationSpeed*0.5f ;
        float rotx = currentRotationX +inputManager.rotationCanonInput.x * rotationSpeed;
        currentRotationY = Mathf.Clamp(roty, 0,20);
        currentRotationX = Mathf.Clamp(rotx, -45, 45);
       
        canon.localRotation = Quaternion.Euler(-roty, rotx, 0);
    }

}
