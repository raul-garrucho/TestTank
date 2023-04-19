using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform canon;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float shootCD;
    [SerializeField]
    private PoolManager poolManager = null;

    private InputManager inputManager;
    private PlayerStats data;
    private bool readyForShoot = true;
    private float currentRotationX;
    private float currentRotationY;


    // public string shooterId;
    private void Awake()
    {
        inputManager = transform.GetComponent<InputManager>();
        data = GetComponent<PlayerStats>();

    }
    private void FixedUpdate()
    {
        SetCurrentRotation();

        if (inputManager.shootButton && readyForShoot && data.amountOfAmmo > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyForShoot = false;
        data.AddAmmo(-1);
        Quaternion lookDirectio = Quaternion.LookRotation(canon.forward);

        Bullet bullet = null;

        if (poolManager.IsPoolEmpty)
        {
            GameObject gBullet = Instantiate(bulletPrefab, firePoint.position, lookDirectio, transform);
            bullet = gBullet.GetComponent<Bullet>();
        }
        else
        {
            bullet = poolManager.GetFromQueue();
        }

        bullet.SetBullet(firePoint.position, lookDirectio);
        bullet.setId(data.attackerId);

        StartCoroutine(RechargTime());
    }

    private void SetCurrentRotation()
    {
        float roty = currentRotationY + inputManager.rotationCanonInput.y * rotationSpeed * 0.5f;
        float rotx = currentRotationX + inputManager.rotationCanonInput.x * rotationSpeed;
        currentRotationY = Mathf.Clamp(roty, 0, 20);
        currentRotationX = Mathf.Clamp(rotx, -45, 45);

        canon.localRotation = Quaternion.Euler(-roty, rotx, 0);
    }

    IEnumerator RechargTime()
    {
        WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(shootCD);

        yield return waitForSecondsRealtime;

        readyForShoot = true;
    }
}
