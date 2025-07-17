using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewprefab;

    public CardView CreateCardView(Card card, Vector3 position, Quaternion rotation)
    {
        CardView cardView = Instantiate(cardViewprefab, position, rotation);
        cardView.Setup(card);
        return cardView;
    }
}
