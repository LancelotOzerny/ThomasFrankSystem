using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

public class CCardsManager : MonoBehaviour
{
    private List<CCard> cards = new List<CCard>();
    private XMLContainer xml;
    private CCreator trainer;

    private void Start()
    {
        xml = GameObject.FindGameObjectWithTag("xml").GetComponent<XMLContainer>();
        trainer = GameObject.FindGameObjectWithTag("creator").GetComponent<CCreator>();
        LoadCards();
    }

    /// <summary>
    /// ћетод загрузки карточек
    /// </summary>
    private void LoadCards()
    {
        foreach (XmlElement xmlCard in xml.Cards)
        {
            cards.Add(new CCard(xmlCard));
        }
    }

    /// <summary>
    /// ћетод, позвол€ющий реализовать создание карточки из набора CCreator данных
    /// </summary>
    public void Create()
    {
        if (trainer == null)
        {
            Debug.LogAssertion("Trainer is null!");
            return;
        }

        CCard card = new CCard(trainer.Title, trainer.Description);
        
        XmlElement element = xml.GetNewXmlElement("card");
        element.SetAttribute("title", card.Title);
        element.SetAttribute("description", card.Description);
        element.SetAttribute("CheckDate", card.CheckDate.ToString("yyyy.MM.dd", CultureInfo.CurrentCulture));
        element.SetAttribute("box", card.Box.ToString());
        card.SetXmlElement(element);
        cards.Add (card);


        xml.AddElementToContainer(element);
        trainer.Clear();
    }
}
