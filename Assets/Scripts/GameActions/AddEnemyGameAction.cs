using UnityEngine;

public class AddEnemyGameAction : GameAction
{
    public EnemyView EnemyView { get; set; }

    public AddEnemyGameAction (EnemyView enemyView)
    {
        EnemyView = enemyView;
    }
}
