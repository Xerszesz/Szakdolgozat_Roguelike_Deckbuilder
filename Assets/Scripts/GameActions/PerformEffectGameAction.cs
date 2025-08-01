using UnityEngine;

public class PerformEffectGameAction : GameAction
{
    public Effect Effect { get; set; }
    public PerformEffectGameAction(Effect effect)
    {
        Effect = effect;
    }
}
