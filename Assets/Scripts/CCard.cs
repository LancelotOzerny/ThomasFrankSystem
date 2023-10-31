using System;
using System.Globalization;
using System.Xml;

/// <summary>
/// Карточка для тренировки
/// </summary>
public class CCard
{
    private XmlElement xmlCard;
    private string title;
    private string description;
    private DateTime checkDate;
    private int box;

    public string Title { get => title; }
    public string Description { get => description; }
    public DateTime CheckDate { get => checkDate; }
    public int Box { get => box; }
    
    /// <summary>
    /// Установка Xml элемента карточки
    /// </summary>
    /// <param name="element">Присваиваемый xml элемент</param>
    public void SetXmlElement(XmlElement element)
    {
        xmlCard = element;
    }

    public CCard(string title, string description) 
    {
        this.title = title;
        this.description = description;
        this.checkDate = DateTime.Now.Date;
        box = 1;
    }

    public CCard(string title, string description, DateTime checkDate,int box)
    {
        this.title = title;
        this.description = description;
        this.checkDate = checkDate;
        this.box = box;
    }

    public CCard(XmlElement element)
    {
        xmlCard = element;
        this.title = element.GetAttribute("title");
        this.description = element.GetAttribute("description");
        this.checkDate = DateTime.ParseExact(element.GetAttribute("checkDate"), "yyyy.MM.dd", CultureInfo.CurrentCulture);
        this.box = int.Parse(element.GetAttribute("box"));
    }
}
