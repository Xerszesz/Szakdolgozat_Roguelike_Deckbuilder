using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    //Ebbe a list�ba csak reward k�rty�k val�k, az alapok nem
    [SerializeField] private List<CardData> allRewardCards;


    public void AddOneRandomRewardToDeck(HeroData heroData)
    {
        if (allRewardCards == null || allRewardCards.Count == 0 || heroData == null)
            return;

        var randomCard = allRewardCards[Random.Range(0, allRewardCards.Count)];
        if (!heroData.StarterDeck.Contains(randomCard))
            heroData.StarterDeck.Add(randomCard);
    }
}
