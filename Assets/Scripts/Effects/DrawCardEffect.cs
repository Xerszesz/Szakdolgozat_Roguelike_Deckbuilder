using UnityEngine;

public class DrawCardEffect : Effect
{
    [SerializeField] private int drawAmount;
    public override GameAction GetGameAction()
    {
        DrawCardsGameAction drawCardsGA = new(drawAmount);
        return drawCardsGA;
    } 
}
