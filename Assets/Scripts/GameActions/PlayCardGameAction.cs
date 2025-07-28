using UnityEngine;

public class PlayCardGameAction : GameAction
{
    public Card Card { get; set; }
    public PlayCardGameAction(Card card)
    {
        Card = card;
    }
}
