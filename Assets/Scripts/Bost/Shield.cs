using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Bost
{
    public override void Bosst(PlayerStats player)
    {
        player.AddShield();
        PoolManager.Instance.AddShield(this);
    }
}
