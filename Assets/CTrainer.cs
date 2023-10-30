using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class CTrainer : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] [TextArea] private string noneCardsText = "Карточек для тренировки  \r\nна сегодня нет.";
    [SerializeField] private CCard cardsManager;

    [SerializeField] private List<CardInfo> cards = new List<CardInfo>();

    private void OnEnable()
    {
        text.text = noneCardsText;
        cards = cardsManager.GetTrainCards();

        Debug.Log(cards.Count);
        
        if (cards.Count > 0 )
        {
            text.text = cards[0].Title;
        }
    }


}
