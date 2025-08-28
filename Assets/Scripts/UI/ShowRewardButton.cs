using UnityEngine;

public class ShowRewardButton : MonoBehaviour
{
    [SerializeField] private GameObject RewardSystem;
    
    public void OnClick()
    {
        RewardSystem.GetComponent<RewardSystem>().GenerateRewardCardsUI();

        this.gameObject.SetActive(false);
    }
}
