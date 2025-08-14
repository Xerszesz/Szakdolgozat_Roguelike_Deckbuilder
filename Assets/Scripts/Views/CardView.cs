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
    [SerializeField] private LayerMask dropareaLayer;


    public Card Card { get; private set; }


    //eredeti helye �s forg�sa
    private Vector3 dragStartposition;
    private Quaternion dragStartrotation;

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
        if (!InteractionSystem.Instance.PlayerCanHover())
        {
            return;
        }
        wrapper.SetActive(false);
        Vector3 position = new(transform.position.x, -2, 0);
        CardViewHoverSystem.Instance.Show(Card,position);
    }
    
    void OnMouseExit()
    {
        if (!InteractionSystem.Instance.PlayerCanHover())
        {
            return;
        }
        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }

    //Mindegyikn�l csak akkor t�rt�nik meg ha a j�t�kos �ppen interakt�lhat

    private void OnMouseDown()
    {
        if (!InteractionSystem.Instance.PlayerCanInteract())
        {
            return;
        }
        if (Card.ManualTargetEffect != null)
        {
            ManualTargetingSystem.Instance.StartTargeting(transform.position);
        }
        else
        {
            //wrappert visszakapcsoljuk, a hover pedig ki

            InteractionSystem.Instance.PlayerIsDragging = true;
            wrapper.SetActive(true);
            CardViewHoverSystem.Instance.Hide();

            //t�rolni eredeti hely �s rota
            dragStartposition = transform.position;
            dragStartrotation = transform.rotation;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
        }


        
    }

    

    private void OnMouseDrag()
    {
        if (!InteractionSystem.Instance.PlayerCanInteract())
        {
            return;
        }

        if (Card.ManualTargetEffect != null)
        {
            return;
        }
        
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }

    private void OnMouseUp()
    {
        if (!InteractionSystem.Instance.PlayerCanInteract())
        {
            return;
        }

        if (Card.ManualTargetEffect != null)
        {
            EnemyView target = ManualTargetingSystem.Instance.EndTargeting(MouseUtil.GetMousePositionInWorldSpace(-1));
            if (target != null && EnergySystem.Instance.HasEnoughEnergy(Card.Energy))
            {
                PlayCardGameAction playCardGA = new(Card, target);
                ActionSystem.Instance.Perform(playCardGA);
            }
        }
        else
        {
            if (EnergySystem.Instance.HasEnoughEnergy(Card.Energy)
           && Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 10f, dropareaLayer))

            {
                PlayCardGameAction playCardGA = new(Card);
                ActionSystem.Instance.Perform(playCardGA);
            }
            else
            {
                transform.position = dragStartposition;
                transform.rotation = dragStartrotation;
            }
            InteractionSystem.Instance.PlayerIsDragging = false;

        }



    }

}
