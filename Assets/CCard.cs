using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
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
        ReadXml();
    }

    private void ReadXml()
    {
        xmlDoc.Load(xmlPath);

        foreach (XmlNode node in xmlDoc.ChildNodes)
        {
            if (node.Name.ToLower() == "cards")
            {
                container = (XmlElement)node;
                break;
            }
        }

        foreach (XmlNode node in xmlDoc.ChildNodes)
        {
            if (node.Name.ToLower() == "card")
            {
                Debug.Log(node.Name);
                cards.Add(new CardInfo(
                    ((XmlElement)node).GetAttribute("title"),
                    ((XmlElement)node).GetAttribute("description"),
                    DateTime.ParseExact(
                        ((XmlElement)node).GetAttribute("checkDate"),
                        "yyyy.MM.dd",
                        System.Globalization.CultureInfo.InvariantCulture
                    )
                ));
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
}