using UnityEngine;
using TMPro;
using System;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text energy;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;


    public Card Card { get; private set; }
    public void Setup(Card card)
    {
        Card = card;
        title.text = card.Title;
        description.text = card.Description;
        energy.text = card.Energy.ToString();
        imageSR.sprite = card.Image;
    }

    void OnMouseEnter()
    {
        wrapper.SetActive(false);
        Vector3 position = new(transform.position.x, -2, 0);
        CardViewHoverSystem.Instance.Show(Card,position);
    }
    
    void OnMouseExit()
    {
        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }
}
