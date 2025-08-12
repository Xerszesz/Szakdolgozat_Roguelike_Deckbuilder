using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private GameObject damageVFX;

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
            Instantiate(damageVFX, target.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
