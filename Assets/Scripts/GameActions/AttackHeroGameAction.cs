using UnityEngine;

public class AttackHeroGameAction : GameAction
{
    public EnemyView Attacker { get; private set; }

   public AttackHeroGameAction(EnemyView attacker)
    {
        Attacker = attacker;
    }
}
