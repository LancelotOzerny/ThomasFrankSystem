using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CCardsManager : MonoBehaviour
{
    private List<CCard> cards = new List<CCard>();
    private XMLContainer xml;

    private void Start()
    {
        xml = GameObject.FindGameObjectWithTag("xml").GetComponent<XMLContainer>();
        LoadCards();
    }

    private void LoadCards()
    {
        foreach (XmlElement xmlCard in xml.Cards)
        {
            cards.Add(new CCard(xmlCard));
        }
    }
}
