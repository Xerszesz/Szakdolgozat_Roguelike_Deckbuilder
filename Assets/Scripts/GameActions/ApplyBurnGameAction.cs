using UnityEngine;

public class ApplyBurnGameAction : GameAction
{
   public int BurnDamage { get; private set; }

    public CombatantView Target { get; private set; }
    public ApplyBurnGameAction(int burnDamage, CombatantView target)
    {
        BurnDamage = burnDamage;
        Target = target;
    }
}
