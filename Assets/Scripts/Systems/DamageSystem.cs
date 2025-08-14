using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyDamagedVFX;
    [SerializeField] private GameObject heroDamagedVFX;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DealDamageGameAction>(DealDamagePerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DealDamageGameAction>();
    }

    private IEnumerator DealDamagePerformer(DealDamageGameAction dealDamageGA)
    {
        foreach (var target in dealDamageGA.Targets)
        {
            target.Damage(dealDamageGA.Amount);
            if (target is EnemyView enemyView)
            {
                Instantiate(enemyDamagedVFX, target.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(heroDamagedVFX, target.transform.position, Quaternion.identity);
            }

                yield return new WaitForSeconds(0.15f);
            if (target.CurrentHealth <= 0)
            {
                if (target is EnemyView enemyView1)
                {
                    KillEnemyGameAction killEnemyGA = new(enemyView1);
                    ActionSystem.Instance.AddReaction(killEnemyGA);
                }
                else
                {
                    // Nothing for now
                    //Game Over Scene, Hero lost all health
                }
            }
        }
    }
}
