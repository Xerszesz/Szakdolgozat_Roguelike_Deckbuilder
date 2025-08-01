using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : Singleton<CardSystem>
{
    [SerializeField] private HandView handView;
    [SerializeField] private Transform drawPilePoint;
    [SerializeField] private Transform discardPilePoint;

    private readonly List<Card> drawPile = new();
    private readonly List<Card> hand = new();
    private readonly List<Card> discardPile = new();

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DrawCardsGameAction>(DrawCardPerformer);
        ActionSystem.AttachPerformer<DiscardAllCardsGameAction>(DiscardAllCardPerformer);
        ActionSystem.AttachPerformer<PlayCardGameAction>(PlayCardPerformer);
        ActionSystem.SubscribeReaction<EnemyTurnGameAction>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.SubscribeReaction<EnemyTurnGameAction>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DrawCardsGameAction>();
        ActionSystem.DetachPerformer<DiscardAllCardsGameAction>();
        ActionSystem.DetachPerformer<PlayCardGameAction>();
        ActionSystem.UnsubscribeReaction<EnemyTurnGameAction>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.UnsubscribeReaction<EnemyTurnGameAction>(EnemyTurnPostReaction, ReactionTiming.POST);
    }
    //Publics
    public void Setup(List<CardData> deckData)
    {
        foreach (var cardData in deckData)
        {
            Card card = new(cardData);
            drawPile.Add(card);
        }
    }

    //Performers

    private IEnumerator DrawCardPerformer(DrawCardsGameAction drawCardGA)
    {
        int actualAmount = Mathf.Min(drawCardGA.Amount, drawPile.Count);
        int notDrawnAmount = drawCardGA.Amount - actualAmount;
        for (int i = 0; i < actualAmount; i++)
        {
            yield return DrawCard();
        }
        if (notDrawnAmount > 0)
        {
            RefillDeck();
            for (int i = 0; i < notDrawnAmount; i++)
            {
                yield return DrawCard();
            }
        }
    }

    private IEnumerator DiscardAllCardPerformer(DiscardAllCardsGameAction discardAllCardGA)
    {
        foreach (var card in hand)
        {
            discardPile.Add(card);
            CardView cardView = handView.RemoveCard(card);
            yield return DiscardCard(cardView);
        }
        hand.Clear();
    }

    private IEnumerator PlayCardPerformer(PlayCardGameAction playCardGA)
    {
        hand.Remove(playCardGA.Card);
        CardView cardview = handView.RemoveCard(playCardGA.Card);
        yield return DiscardCard(cardview);

        SpendEnergyGameAction spendEnergyGA = new(playCardGA.Card.Energy);
        ActionSystem.Instance.AddReaction(spendEnergyGA);

        foreach (var effect in playCardGA.Card.Effects)
        {
            PerformEffectGameAction performEffectGA = new(effect);
            ActionSystem.Instance.AddReaction(performEffectGA);
        }
    }
    //Reactions

    private void EnemyTurnPreReaction(EnemyTurnGameAction enemyturnGA)
    {
        DiscardAllCardsGameAction discardAllCardsGA = new();
        ActionSystem.Instance.AddReaction(discardAllCardsGA);
    }

    private void EnemyTurnPostReaction(EnemyTurnGameAction enemyturnGA)
    {
        DrawCardsGameAction drawCardsGA = new(5);
        ActionSystem.Instance.AddReaction(drawCardsGA);
    }


    //Helpers

    private IEnumerator DrawCard()
    {
        Card card = drawPile.Draw();
        hand.Add(card);
        CardView cardView = CardViewCreator.Instance.CreateCardView(card,drawPilePoint.position,drawPilePoint.rotation);
        yield return handView.AddCard(cardView);
    }

    private void RefillDeck()
    {
        drawPile.AddRange(discardPile);
        discardPile.Clear();
    }

    private IEnumerator DiscardCard(CardView cardView)
    {
        cardView.transform.DOScale(Vector3.zero, 0.15f);
        Tween tween = cardView.transform.DOMove(discardPilePoint.position,0.15f);
        yield return tween.WaitForCompletion();
        Destroy(cardView.gameObject);
    }
}
