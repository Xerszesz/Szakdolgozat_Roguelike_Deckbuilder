using System.Collections.Generic;
using UnityEngine;

public class HeroTargetMode : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        List< CombatantView> targets = new()
        {
            HeroSystem.Instance.HeroView
        };
        return targets;
    }
}
