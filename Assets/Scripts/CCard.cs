using System;
using System.Globalization;
using System.Xml;

public class CCard
{
    private XmlElement xmlCard;
    private string title;
    private string description;
    private DateTime checkDate;
    private int box;

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
