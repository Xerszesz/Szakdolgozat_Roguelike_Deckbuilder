using UnityEngine;

public class AddRewardButton : MonoBehaviour
{
    [SerializeField] private RewardSystem rewardSystem;
    [SerializeField] private HeroData heroData;

    [SerializeField] private GameObject CardSelectionCanvas;

    public void OnClick()
    {
        rewardSystem.AddOneRandomRewardToDeck(heroData);
        //Hide the reward UI
        CardSelectionCanvas.SetActive(false);
    }
}
