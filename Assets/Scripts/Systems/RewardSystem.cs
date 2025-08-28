using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour
{
    //Ebbe a listába csak reward kártyák valók, az alapok nem
    [SerializeField] private List<CardData> allRewardCards;

    [SerializeField] private RewardSelectionUI rewardSelectionUI;
    [SerializeField] private HeroData heroData;


    public void AddSpecificRewardToDeck(HeroData heroData, CardData cardData)
    {
        if (heroData == null || cardData == null)
            return;

        heroData.StarterDeck.Add(cardData);
    }

    public void GenerateRewardCardsUI()
    {
        var selected = new List<CardData>();
        while (selected.Count < 3)
        {
            var randomCard = allRewardCards[Random.Range(0, allRewardCards.Count)];
            if (!selected.Contains(randomCard))
                selected.Add(randomCard);
        }

        rewardSelectionUI.ClearSlots();

        foreach (var cardData in selected)
        {
            
            CardViewUI cardViewUI = CardViewUICreator.Instance.CreateCardViewUI(Vector3.zero, Quaternion.identity);

           
            cardViewUI.Setup(cardData, this, heroData, rewardSelectionUI);

            
            Button button = cardViewUI.GetComponentInChildren<Button>();
            if (button != null)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(cardViewUI.OnAddToDeckButtonClicked);
            }

            rewardSelectionUI.AddCardView(cardViewUI);
        }
    }
}
