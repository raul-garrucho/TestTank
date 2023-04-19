using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// spawn de los diferenrtes boosts
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] boostPerfabsList;
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private float respawnBoostTime;
    private State currentState;

    private void Awake()
    {
        ChangeToempty();
    }
    private enum State
    {
        None,
        Empty,
        AmmoRefill,
        VelocityBost,
        Shield
    }
    public void ChangeToempty()
    {
        ChangeState(State.Empty);
    }
    private void ChangeState(State state)
    {
        currentState = state;
        OnEnter();
    }
    private void OnEnter()
    {
        switch (currentState)
        {
            case State.Empty:
                OnEnterEmpy();
                break;
            case State.AmmoRefill:
                OnEnterAmmoRefill();
                break;
            case State.VelocityBost:
                OnEnterVelocityBost();
                break;
            case State.Shield:
                OnEnterShield();
                break;
        }
    }
  
    private void OnEnterEmpy()
    {
        StartCoroutine(CountTime());
    }
    private void OnEnterAmmoRefill()
    {
        Ammorefill bost = null;
        if (poolManager.IsAmmoreFills)
        {
            Instantiate(boostPerfabsList[0],spawnTransform);
        }
        else
        {
            bost = poolManager.GetAmmorefill();
            bost.SetBost(spawnTransform.position);
        }
    }
    private void OnEnterVelocityBost()
    {
        Vboost bost = null;
        if (poolManager.IsVbosstEmpty)
        {
            Instantiate(boostPerfabsList[1], spawnTransform);
        }
        else
        {
            bost = poolManager.GetVbost();
            bost.SetBost(spawnTransform.position);
        }
    }
    private void OnEnterShield()
    {
        Shield bost = null;
        if (poolManager.IsShields)
        {
            Instantiate(boostPerfabsList[2], spawnTransform);
        }
        else
        {
            bost = poolManager.GetShield();
            bost.SetBost(spawnTransform.position);
        }
    }

    IEnumerator CountTime()
    {
        WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(respawnBoostTime);
        yield return waitForSecondsRealtime;
        int selectedBoost = Random.Range(2,boostPerfabsList.Length+2);
        ChangeState((State)selectedBoost);
    }
}
