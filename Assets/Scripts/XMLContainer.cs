using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLContainer : MonoBehaviour
{
    [SerializeField] private string xmlPath = "data/cards.xml";

    private List<XmlElement> cards = new List<XmlElement>();
    private XmlDocument xmlDocument = new XmlDocument();
    private XmlElement container =  null;

    public XmlElement Container {  get { return container; } }
    public List<XmlElement> Cards { get {  return cards; } }

    private void Awake()
    {
        if (File.Exists(xmlPath) == false)
        {
            Create();
        }
        Load();
        ReadContainer();
        ReadCards();
    }

    /// <summary>
    /// �������� Xml-��������� ���� �� �� ����������
    /// </summary>
    private void Create()
    {
        XmlDocument xmlDocument = new XmlDocument();
        XmlElement container = xmlDocument.CreateElement("container");
        xmlDocument.AppendChild(container);
        xmlDocument.Save(xmlPath);
    }

    /// <summary>
    /// �������� Xml ���������
    /// </summary>
    private void Load()
    {
        if (File.Exists(xmlPath) == false)
        {
            Debug.LogError("Xml Document is not founded");
            return;
        }

        this.xmlDocument = new XmlDocument();
        this.xmlDocument.Load(xmlPath);
    }

    /// <summary>
    /// ���������� ��������
    /// </summary>
    private void ReadCards()
    {
        if (this.container == null)
        {
            Debug.LogError("XmlDocument is null");
            return;
        }

        foreach (XmlNode node in this.container.ChildNodes)
        {
            if (node.Name == "card")
            {
                this.cards.Add((XmlElement)node);
            }
        }
    }

    /// <summary>
    /// ���������� ���������� ��������
    /// </summary>
    private void ReadContainer()
    {
        if (this.xmlDocument == null)
        {
            Debug.LogError("XmlDocument is null");
            return;
        }

        foreach (XmlNode node in this.xmlDocument.ChildNodes)
        {
            if (node.Name == "container")
            {
                this.container = (XmlElement)node;
            }
        }
    }

    /// <summary>
    /// ���������� �������� � ��������� � ����������� �����������
    /// </summary>
    /// <param name="element">����������� Xml �������</param>
    public void AddElementToContainer(XmlElement element)
    {
        if (this.xmlDocument == null || this.container == null)
        {
            Debug.LogError("XmlDocument or container is null");
            return;
        }

        this.container.AppendChild(element);
        this.xmlDocument.Save(xmlPath);

        if (element.Name == "card")
        {
            cards.Add(element);
        }
    }

    /// <summary>
    /// �������� �� ���������� ������� � ����������� �����������
    /// </summary>
    /// <param name="element">��������� Xml �������</param>
    public void RemoveElementFromContainer(XmlElement element)
    {
        if (this.xmlDocument == null || this.container == null)
        {
            Debug.LogError("XmlDocument or container is null");
            return;
        }

        this.container.RemoveChild(element);
        this.xmlDocument.Save(xmlPath);

        if (cards.Contains(element))
        {
            cards.Remove(element);
        }
    }

    /// <summary>
    /// ���������� xml ���������
    /// </summary>
    public void Save()
    {
        if (this.xmlDocument == null)
        {
            Debug.LogError("XmlDocument is null");
            return;
        }

        xmlDocument.Save(xmlPath);
    }
}
