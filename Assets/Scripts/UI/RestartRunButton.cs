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

        Destroy(CardSystem.Instance.gameObject);
        Destroy(EnemySystem.Instance.gameObject);
        Destroy(PerkSystem.Instance.gameObject);
        Destroy(ActionSystem.Instance.gameObject);
        

        SceneManager.LoadScene("MainMenu");
    }
}
