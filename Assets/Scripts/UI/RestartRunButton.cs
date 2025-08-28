using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartRunButton : MonoBehaviour
{
    public void OnClick()
    {
        Time.timeScale = 1f;

        DOTween.KillAll();
        DOTween.Clear(true);

        CardSystem.Instance.ResetDeck();
        EnemySystem.Instance.Reset();
        PerkSystem.Instance.Reset();
        ActionSystem.Instance.Reset();

        SceneManager.LoadScene("CombatScene");
    }
}
