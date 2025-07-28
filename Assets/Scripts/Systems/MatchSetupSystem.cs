using System.Collections.Generic;
using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private List<CardData> deckData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        CardSystem.Instance.Setup(deckData);
        DrawCardsGameAction drawCardsGA = new(5);
        ActionSystem.Instance.Perform(drawCardsGA);
    }

}
