using System.Collections.Generic;
using UnityEngine;

public class NoTargetMode : TargetMode
{
    public override List<CombatantView> GetTargets()
    {
        return null;
    }

}
