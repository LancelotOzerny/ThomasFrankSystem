using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTrain : MonoBehaviour
{
    [SerializeField] private CCardsManager manager;
    [SerializeField] private List<CCard> cards = new List<CCard>();

    [SerializeField] Text text;
    [SerializeField] private string zeroCards = string.Empty;
    [SerializeField] private string finish = string.Empty;

    private CCard currentCard = null;

    private static System.Random rand = new System.Random();

    private void OnEnable()
    {
        if (manager == null)
        {
            return;
        }

        foreach (CCard card in manager.Cards)
        {
            if (DateTime.Today >= card.CheckDate)
            {
                cards.Add(card);
            }
        }

        if (cards.Count > 0)
        {
            currentCard = cards[0];
            text.text = currentCard.Title;
        }
        else
        {
            text.text = zeroCards;
        }
    }

    private void SetRandCard()
    {
        if (cards.Count == 0)
        {
            return;
        }

        currentCard = cards[rand.Next(0, cards.Count - 1)];
        this.text.text = currentCard.Title;
    }

    public void SetRightTouch()
    {
        if (currentCard != null)
        {
            currentCard.NextBox();
            cards.Remove(currentCard);
            currentCard = null;

            if (cards.Count == 0)
            {
                text.text = finish;
            }

            SetRandCard();
        }
    }

    public void SetBadTouch()
    {
        if (currentCard != null)
        {
            currentCard.PrevBox();
            cards.Remove(currentCard);
            currentCard = null;

            if (cards.Count == 0)
            {
                text.text = finish;
            }

            SetRandCard();
        }
    }

    public void Flip()
    {
        if (text == null || currentCard == null)
        {
            return;
        }

        if (text.text == currentCard.Title)
        {
            text.text = currentCard.Description;
        }
        else
        {
            text.text = currentCard.Title;
        }
    }
}
