using UnityEngine;

public class CardViewUICreator : Singleton<CardViewUICreator>
{
    [SerializeField] private CardViewUI cardViewUIprefab;

    public CardViewUI CreateCardViewUI(Card card, Vector3 position, Quaternion rotation)
    {
        CardViewUI cardViewUI = Instantiate(cardViewUIprefab, position, rotation);
        cardViewUI.Setup(card);
        return cardViewUI;
    }
}
