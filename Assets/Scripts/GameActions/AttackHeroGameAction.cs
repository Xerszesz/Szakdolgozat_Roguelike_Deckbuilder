using UnityEngine;

public class AttackHeroGameAction : GameAction, IHaveCaster
{
    public EnemyView Attacker { get; private set; }

    public CombatantView Caster { get; private set; }

    public AttackHeroGameAction(EnemyView attacker)
    {
        Attacker = attacker;
        Caster = Attacker;
    }
}
