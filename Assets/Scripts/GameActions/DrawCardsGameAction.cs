using UnityEngine;

public class DrawCardsGameAction : GameAction
{
    public int Amount { get; set; }

    public DrawCardsGameAction(int amount)
    {
        Amount = amount;
    }
}
