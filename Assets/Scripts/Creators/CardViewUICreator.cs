using UnityEngine;

public class CardViewUICreator : Singleton<CardViewUICreator>
{
    [SerializeField] private CardViewUI cardViewUIprefab;

    public CardViewUI CreateCardViewUI(Vector3 position, Quaternion rotation)
    {
        return Instantiate(cardViewUIprefab, position, rotation);
    }
}
