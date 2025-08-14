using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesTargetMode : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        return new(EnemySystem.Instance.Enemies);
    }
}
