using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CCard : MonoBehaviour
{
    [SerializeField] private string xmlPath = string.Empty;
    
    private XmlDocument xmlDoc = new XmlDocument();
    private XmlElement container = null;

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
                    )
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

        Debug.Log($"Result = {result.Count}");
        Debug.Log($"Counts = {cards.Count}");

        return result;
    }
}