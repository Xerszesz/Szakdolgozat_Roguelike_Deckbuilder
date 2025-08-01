using UnityEngine;

public class SpendEnergyGameAction : GameAction
{
    public int Amount { get; set; }
    public SpendEnergyGameAction(int amount)
    {
        Amount = amount;
    }
}
