using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Hero")]
public class HeroData : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public Sprite DeathImage { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public List<CardData> StarterDeck { get; private set; }
}
