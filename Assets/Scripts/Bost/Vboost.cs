using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vboost : Bost
{
    [SerializeField] private float speedMod;
    public override void Bosst(PlayerStats player)
    {
        player.velocityBoost(speedMod);
    }
}
