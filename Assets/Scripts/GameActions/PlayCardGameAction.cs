using UnityEngine;

public class PlayCardGameAction : GameAction
{
    public EnemyView ManualTarget { get; set; }
    public Card Card { get; set; }
    public PlayCardGameAction(Card card)
    {
        Card = card;
        ManualTarget = null;
    }

    public PlayCardGameAction(Card card,EnemyView target)
    {
        Card = card;
        ManualTarget = target;
    }
}
