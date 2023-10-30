using System;

public class CardInfo
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CheckDay { get; set; }

    public CardInfo(string title, string description, DateTime nextDay)
    {
        Title = title;
        Description = description;
        this.CheckDay = nextDay;
    }

    public CardInfo(string title, string description)
    {
        Title = title;
        Description = description;
        this.CheckDay = DateTime.Today.AddDays(1)   ;
    }
}