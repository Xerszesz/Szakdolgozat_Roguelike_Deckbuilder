using System.Collections.Generic;
using UnityEngine;

public class DealDamageGameAction : GameAction
{
    public int Amount { get; set; }
    public List<CombatantView> Targets { get; set; }

    public DealDamageGameAction(int amount, List<CombatantView> targets)
    {
        Amount = amount;
        Targets = new(targets);
    }
}
