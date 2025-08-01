using TMPro;
using UnityEngine;

public class EnemyView : CombatantView
{
    [SerializeField] TMP_Text attackText;
    public int AttackPower { get; set; }

    public void Setup(EnemyData enemyData)
    {
        AttackPower = enemyData.AttackPower;
        UpdateAttackText();
        SetupBase(enemyData.Health, enemyData.Image);
    }

    private void UpdateAttackText()
    {
        attackText.text = "Attack: " + AttackPower;
    }
}
