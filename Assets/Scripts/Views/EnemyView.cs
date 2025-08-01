using TMPro;
using UnityEngine;

public class EnemyView : CombatantView
{
    [SerializeField] TMP_Text attackText;
    public int AttackPower { get; set; }

    public void Setup()
    {
        AttackPower = 10;
        SetupBase(AttackPower,null);
    }

    private void UpdateAttackText()
    {
        attackText.text = "Attack: " + AttackPower;
    }
}
