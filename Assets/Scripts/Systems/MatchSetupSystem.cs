using System.Collections.Generic;
using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        HeroSystem.Instance.Setup(heroData);
        CardSystem.Instance.Setup(heroData.StarterDeck);
        DrawCardsGameAction drawCardsGA = new(5);
        ActionSystem.Instance.Perform(drawCardsGA);
    }

}
