using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : Singleton<EnemySystem>
{
    [SerializeField] private EnemyBoardView enemyBoardView;
    public List<EnemyView> Enemies => enemyBoardView.EnemyViews;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGameAction>(EnemyTurnPerformer);
        ActionSystem.AttachPerformer<AttackHeroGameAction>(AttackHeroPerformer);
        ActionSystem.AttachPerformer<KillEnemyGameAction>(KillEnemyPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGameAction>();
        ActionSystem.DetachPerformer<AttackHeroGameAction>();
        ActionSystem.DetachPerformer<KillEnemyGameAction>();

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
        foreach (var enemy in enemyBoardView.EnemyViews)
        {
            AttackHeroGameAction attackHeroGA = new(enemy);
            ActionSystem.Instance.AddReaction(attackHeroGA);

        }
        yield return null;
        
    }

    private IEnumerator AttackHeroPerformer(AttackHeroGameAction attackHeroGA)
    {
        EnemyView attacker = attackHeroGA.Attacker;

        //Attack "animation"
        Tween tween = attacker.transform.DOMoveY(attacker.transform.position.y + 1f, 0.15f);
        yield return tween.WaitForCompletion();
        attacker.transform.DOMoveY(attacker.transform.position.y - 1f, 0.25f);

        //Deal Damage
        DealDamageGameAction dealDamageGA = new(attacker.AttackPower, new() {HeroSystem.Instance.HeroView });
        ActionSystem.Instance.AddReaction(dealDamageGA);
    }

    private IEnumerator KillEnemyPerformer(KillEnemyGameAction killEnemyGA)
    {
        yield return enemyBoardView.RemoveEnemy(killEnemyGA.EnemyView);

    }
}
