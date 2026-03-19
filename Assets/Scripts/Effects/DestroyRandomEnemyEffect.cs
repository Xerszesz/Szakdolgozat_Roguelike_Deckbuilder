using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DestroyRandomEnemyEffect : Effect
{
    public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
    {
        EnemyView enemyTarget = targets[0] as EnemyView;

        return new KillEnemyGameAction(enemyTarget);
    }
}
