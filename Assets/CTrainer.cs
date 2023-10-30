using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

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
        ChangeCard();
    }

    public void SetBadTouch()
    {
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
