using System.Collections.Generic;
using UnityEngine;

public class DestroyRandomEnemyEffect : Effect
{
    public override GameAction GetGameAction()
    {
        List<EnemyView> enemies = new(EnemySystem.Instance.Enemies);

        if (enemies.Count == 0)
        {
            Debug.LogWarning("No more enemy");
            return null;
        }

        // Véletlenszerû ellenség kiválasztása
        int randomIndex = Random.Range(0, enemies.Count);
        EnemyView chosenEnemy = enemies[randomIndex];

        KillEnemyGameAction killEnemyGA = new KillEnemyGameAction(chosenEnemy);

        return killEnemyGA;
    }
}
