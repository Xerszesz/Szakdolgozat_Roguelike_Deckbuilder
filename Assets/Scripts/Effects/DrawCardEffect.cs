using System.Collections.Generic;
using UnityEngine;

public class DrawCardEffect : Effect
{
    [SerializeField] private int drawAmount;
    public override GameAction GetGameAction(List<CombatantView> targets)
    {
        DrawCardsGameAction drawCardsGA = new(drawAmount);
        return drawCardsGA;
    } 
}
