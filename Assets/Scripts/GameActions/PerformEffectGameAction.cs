using System.Collections.Generic;
using UnityEngine;

public class PerformEffectGameAction : GameAction
{
    public Effect Effect { get; set; }

    public List<CombatantView> Targets { get; set; }
    public PerformEffectGameAction(Effect effect,List<CombatantView> targets)
    {
        Effect = effect;
        Targets = targets == null ? null : new(targets);
    }
}
