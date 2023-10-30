using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class CCard : MonoBehaviour
{
    [SerializeField] private string xmlPath = string.Empty;
    
    private XmlDocument xmlDoc = new XmlDocument();
    private XmlNode container = null;

    [SerializeField] private List<CardInfo> cards = new List<CardInfo>(); 

    private void Awake()
    {
        if (xmlPath == string.Empty)
        {
            xmlPath = "data\\data.xml";
        }

        createXml();
        ReadXml(xmlDoc);
    }

    private void ReadXmlElement(XmlNode node)
    {
        switch (node.Name.ToLower())
        {
            case "cards":
                container = (XmlElement)node;
                break;

            case "card":
                cards.Add(new CardInfo(
                    ((XmlElement)node).GetAttribute("title"),
                    ((XmlElement)node).GetAttribute("description"),
                    DateTime.ParseExact(
                        ((XmlElement)node).GetAttribute("checkDate"),
                        "yyyy.MM.dd",
                        System.Globalization.CultureInfo.InvariantCulture
                    ),
                    int.Parse(((XmlElement)node).GetAttribute("box"))
                ));
                break;
        }
    }

    private void ReadXml(XmlNode xml)
    {
        xmlDoc.Load(xmlPath);

        foreach (XmlNode node in xml.ChildNodes)
        {
            ReadXmlElement(node);

            if (node.HasChildNodes)
            {
                ReadXml(node);
            }
        }
    }

    private void CreateFolder()
    {
        xmlPath = xmlPath.Replace("/", "\\");
        string[] path = xmlPath.Split('\\');
        string currentPath = ".";

        for (int i = 0; i < path.Length - 1; i++)
        {
            currentPath += "\\" + path[i];
            if (Directory.Exists(currentPath) == false)
            {
                Directory.CreateDirectory(currentPath);
            }
        }
    }

    private void createXml()
    {
        if (File.Exists(xmlPath) == false)
        {
            CreateFolder();

            XmlDocument document = new XmlDocument();
            document.InnerXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<cards>\n</cards>";
            document.Save(xmlPath);
        }
    }

    public bool createCard(CardInfo info)
    {
        if (container == null)
        {
            container = xmlDoc.CreateElement("cards");
            xmlDoc.AppendChild(container);
        }

        XmlElement card = xmlDoc.CreateElement("card");
        card.SetAttribute("title", info.Title);
        card.SetAttribute("description", info.Description);
        card.SetAttribute("checkDate", info.CheckDay.ToString("yyyy.MM.dd"));
        card.SetAttribute("box", info.Box.ToString());
        container.AppendChild(card);

        xmlDoc.Save(xmlPath);
        cards.Add(info);

        return true;
    }

    public List<CardInfo> GetTrainCards()
    {
        List<CardInfo> result = new List<CardInfo>();

        foreach (CardInfo card in cards)
        {
            if (card.CheckDay <= DateTime.Now)
            {
                result.Add(card);
            }
        }

        return result;
    }

    public void RemoveCard(CardInfo card)
    {
        if (container == null)
        {
            container = xmlDoc.CreateElement("cards");
            xmlDoc.AppendChild(container);
        }

        foreach (XmlNode cardNode in container)
        {
            string title = ((XmlElement)cardNode).GetAttribute("title");
            string description = ((XmlElement)cardNode).GetAttribute("description");

            if (title == card.Title && description == card.Description)
            {
                container.RemoveChild(cardNode);
                xmlDoc.Save(xmlPath);

                return;
            }
        }
    }

    public void SaveCard(CardInfo card)
    {

    }
}