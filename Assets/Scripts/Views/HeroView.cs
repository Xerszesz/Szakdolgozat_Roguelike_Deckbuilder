using UnityEngine;

public class HeroView : CombatantView
{
    private HeroData heroData;

    public void Setup(HeroData heroData)
    {
        this.heroData = heroData;
        SetupBase(heroData.Health, heroData.Image);
    }

    public void SetRuinedSprite()
    {
        if (heroData != null && heroData.DeathImage != null)
            SetSprite(heroData.DeathImage);
    }
}
