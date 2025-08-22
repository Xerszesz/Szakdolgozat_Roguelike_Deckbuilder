using UnityEngine;

public class HeroSystem : Singleton<HeroSystem>
{
 [field: SerializeField] public HeroView HeroView { get; private set; }

    public void OnEnable()
    {
        ActionSystem.SubscribeReaction<EnemyTurnGameAction>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.SubscribeReaction<EnemyTurnGameAction>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    public void OnDisable()
    {
        ActionSystem.UnsubscribeReaction<EnemyTurnGameAction>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.UnsubscribeReaction<EnemyTurnGameAction>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    public void Setup(HeroData heroData)
    {
        HeroView.Setup(heroData);
    }

    //Reactions

    private void EnemyTurnPreReaction(EnemyTurnGameAction enemyturnGA)
    {
        DiscardAllCardsGameAction discardAllCardsGA = new();
        ActionSystem.Instance.AddReaction(discardAllCardsGA);
    }

    private void EnemyTurnPostReaction(EnemyTurnGameAction enemyturnGA)
    {
        int burnStacks = HeroView.GetStatusEffectStacks(StatusEffectType.BURN);
        if (burnStacks > 0)
        {
            ApplyBurnGameAction applyBurnGA = new(burnStacks, HeroView);
            ActionSystem.Instance.AddReaction(applyBurnGA);
        }
        DrawCardsGameAction drawCardsGA = new(5);
        ActionSystem.Instance.AddReaction(drawCardsGA);
    }
}
