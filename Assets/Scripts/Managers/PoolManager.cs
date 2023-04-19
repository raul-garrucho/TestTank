using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    private Queue<Bullet> pool = new Queue<Bullet>();
    private Queue<Vboost> vboosts = new Queue<Vboost>();
    private Queue<Ammorefill> ammorefills = new Queue<Ammorefill>();
    private Queue<Shield> shields = new Queue<Shield>();
    public bool IsPoolEmpty { get { return pool.Count == 0; } }
    public bool IsVbosstEmpty { get { return vboosts.Count == 0; } }
    public bool IsAmmoreFills { get { return ammorefills.Count == 0; } }
    public bool IsShields { get { return shields.Count == 0; } }

    private void Awake()
    {
        Instance = this;
    }
    public void AddToQueue(Bullet bullet)
    {
        pool.Enqueue(bullet);
    }
    public Bullet GetFromQueue()
    {
        return pool.Dequeue();
    }
    public void AddVbodt(Vboost vboost)
    {
        vboosts.Enqueue(vboost);
    }
    public Vboost GetVbost()
    {
        return vboosts.Dequeue();
    }
    public void AddAmmo(Ammorefill ammorefill)
    {
        ammorefills.Enqueue(ammorefill);
    }
    public Ammorefill GetAmmorefill()
    {
        return ammorefills.Dequeue();
    }
    public void AddShield(Shield shield)
    {
        shields.Enqueue(shield);
    }
    public Shield GetShield()
    {
        return shields.Dequeue();
    }
}
