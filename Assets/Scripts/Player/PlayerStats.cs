using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplayy;
using System;
//Player Data y Ui Controller

public class PlayerStats : MonoBehaviour
{
     private int hp =  1;
     private int lifes = 3;
    
    [SerializeField] private Transform respawnPoint;
    [SerializeField] public string attackerId;

    [SerializeField] public int playerNum;
    [SerializeField] public int amountOfAmmo =10;
    [SerializeField] public float speedModifier = 1 ;
    public static event Action<int, int,int> hpUpdate;
    public static event Action<int, int> ammoUpdate;

    private void Start()
    {
        speedModifier = 1;
        amountOfAmmo = 10;
        ammoUpdate?.Invoke(playerNum, amountOfAmmo);
        hpUpdate?.Invoke(playerNum, hp,lifes);
    }
    public void velocityBoost(float modifier)
    {
        speedModifier = modifier;
        StartCoroutine(CountTime());
    }
    public void AddAmmo(int addedAmmo)
    {
        amountOfAmmo = amountOfAmmo + addedAmmo;
        amountOfAmmo = Mathf.Clamp(amountOfAmmo, 0, 15);
        ammoUpdate?.Invoke(playerNum,amountOfAmmo);
    }
    public void AddShield()
    {
        hp++;
        hpUpdate?.Invoke(playerNum,hp,lifes);
        hp = Mathf.Clamp(hp, 0, 3);
    }
    public void Dmg()
    {
        hp--;
        hpUpdate?.Invoke(playerNum, hp,lifes);
        if (hp < 1)
        {
            lifes--;
            hp = 1;
            transform.position = respawnPoint.position;
        }
        if (lifes < 1)
        {          
            Gameplay.Instance.ChangeToExit(attackerId);//¿?
            lifes = 3;
        }
    }
    IEnumerator CountTime()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        bool velocityBost = true;
        float currentTime = 0;
        while (velocityBost)
        {
            currentTime += Time.deltaTime;
            if(currentTime > 2)
            {
                speedModifier = 1;
                velocityBost = false;
            }
            yield return wait;
        }
    }
}
