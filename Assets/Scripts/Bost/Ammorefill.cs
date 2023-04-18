using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammorefill : Bost
{
    [SerializeField] private int ammo;
    public override void Bosst(PlayerStats player)
    {
        player.AddAmmo(ammo);
    }
}
