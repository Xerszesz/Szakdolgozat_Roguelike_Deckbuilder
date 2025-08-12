using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : Singleton<EnemySystem>
{
    [SerializeField] private EnemyBoardView enemyBoardView;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGameAction>(EnemyTurnPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGameAction>();
    }

    public void Setup(List<EnemyData> enemyDatas)
    {
        foreach (var enemyData in enemyDatas)
        {
            enemyBoardView.AddEnemy(enemyData);
        }
    }


    //Performer

    private IEnumerator EnemyTurnPerformer(EnemyTurnGameAction enemyTurnGA)
    {
        Debug.Log("Enemy Turn");
        yield return new WaitForSeconds(2f);
        Debug.Log("End Enemy Turn");
    }
}
