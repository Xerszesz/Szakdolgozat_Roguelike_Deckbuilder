using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
