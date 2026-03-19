using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllEnemiesTargetMode : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        return new(EnemySystem.Instance.Enemies);
    }
}
