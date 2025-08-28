using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    //Ebbe a listába csak reward kártyák valók, az alapok nem
    [SerializeField] private List<CardData> allRewardCards;

    [SerializeField] private RewardSelectionUI RewardSelectionUI;


    public void AddOneRandomRewardToDeck(HeroData heroData)
    {
        if (allRewardCards == null || allRewardCards.Count == 0 || heroData == null)
            return;

        var randomCard = allRewardCards[Random.Range(0, allRewardCards.Count)];
        if (!heroData.StarterDeck.Contains(randomCard))
            heroData.StarterDeck.Add(randomCard);
    }

    public void GenerateRewardCardsUI()
    {
        // 1. Véletlenszerûen kiválaszt 3 egyedi kártyát
        var selected = new List<CardData>();
        while (selected.Count < 3)
        {
            var randomCard = allRewardCards[Random.Range(0, allRewardCards.Count)];
            if (!selected.Contains(randomCard))
                selected.Add(randomCard);
        }

        RewardSelectionUI.ClearSlots();

        // 2. CardViewUI példányok létrehozása a CardViewUICreatorral
        var cardViews = new List<CardViewUI>();
        foreach (var cardData in selected)
        {
            Card card = new Card(cardData);
            CardViewUI cardViewUI = CardViewUICreator.Instance.CreateCardViewUI(card, Vector3.zero, Quaternion.identity);
            RewardSelectionUI.AddCardView(cardViewUI);
        }

        
    }
}
