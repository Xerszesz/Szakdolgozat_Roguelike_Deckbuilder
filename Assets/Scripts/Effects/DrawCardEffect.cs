using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DrawCardEffect : Effect
{
    [SerializeField] private int drawAmount;
    public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
    {
        DrawCardsGameAction drawCardsGA = new(drawAmount);
        return drawCardsGA;
    } 
}
