using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Queue<Bullet> pool = new Queue<Bullet>();

    public bool IsPoolEmpty { get { return pool.Count == 0; } }

    public void AddToQueue(Bullet bullet)
    {
        pool.Enqueue(bullet);
    }
    public Bullet GetFromQueue()
    {
        return pool.Dequeue();
    }
}
