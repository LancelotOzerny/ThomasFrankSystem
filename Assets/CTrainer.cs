using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;

public class CTrainer : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] [TextArea] private string noneCardsText = "Карточек для тренировки  \r\nна сегодня нет.";
    [SerializeField] private CCard cardsManager;
    [SerializeField] private List<CardInfo> cards = new List<CardInfo>();
    [SerializeField] private CardInfo currentCard;

    private void OnEnable()
    {
        text.text = noneCardsText;
        cards = cardsManager.GetTrainCards();

        if (cards.Count > 0 )
        {
            SetCardInfo(cards[0]);
        }
    }

    private void SetCardInfo(CardInfo card)
    {
        currentCard = cards[0];
        text.text = currentCard.Title;
    }

    public void FlipCard()
    {
        if (text.text == currentCard.Title)
        {
            text.text = currentCard.Description;
        }
        else
        {
            text.text = currentCard.Title;
        }
    }

    public void SetGoodTouch()
    {
        if (++currentCard.Box > 5)
        {
            cardsManager.RemoveCard(currentCard);
        }
        else
        {
            currentCard.CheckDay = DateTime.Today.AddDays(currentCard.Box);
            cardsManager.SaveCard(currentCard);
        }

        ChangeCard();
    }

    public void SetBadTouch()
    {
        if (--currentCard.Box < 1)
        {
            currentCard.Box = 1;
        }
        
        currentCard.CheckDay = DateTime.Today.AddDays(currentCard.Box);
        cardsManager.SaveCard(currentCard);

        ChangeCard();
    }

    private void ChangeCard()
    {
        cards.Remove(currentCard);
        if (cards.Count == 0)
        {
            text.text = noneCardsText;
            return;
        }

        SetCardInfo(cards[0]);
    }
}
