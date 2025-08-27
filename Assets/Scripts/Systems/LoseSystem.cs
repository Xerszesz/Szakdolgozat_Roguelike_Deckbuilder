using System.Collections;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    [SerializeField] private GameObject loseUI;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<LoseGameAction>(LosePerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<LoseGameAction>();
    }

    private IEnumerator LosePerformer(LoseGameAction loseGA)
    {
        loseUI.SetActive(true);
        yield break;
    }
}
