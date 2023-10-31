using System;

public class CCard
{
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
}
