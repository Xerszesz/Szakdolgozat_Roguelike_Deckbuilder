using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NoTargetMode : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        return null;
    }

}
