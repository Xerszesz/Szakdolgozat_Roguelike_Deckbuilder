using UnityEngine;

public class KillHeroGameAction : GameAction
{
    public HeroView HeroView { get; private set; }

    public KillHeroGameAction(HeroView heroView)
    {
        HeroView = heroView;
    }
}
