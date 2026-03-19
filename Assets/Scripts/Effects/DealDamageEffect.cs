using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DealDamageEffect : Effect
{
    [SerializeField] private int damageAmount;

    public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
    {
        
        DealDamageGameAction dealDamageGA = new(damageAmount,targets,caster);
        return dealDamageGA;
    }
}
