using System.Collections.Generic;
using UnityEngine;

public class DestroyRandomEnemyEffect : Effect
{
    public override GameAction GetGameAction(List<CombatantView> targets)
    {
        EnemyView enemyTarget = targets[0] as EnemyView;

        return new KillEnemyGameAction(enemyTarget);
    }
}
