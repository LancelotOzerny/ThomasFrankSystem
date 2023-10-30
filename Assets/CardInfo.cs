using System;

public class CardInfo
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CheckDay { get; set; }
    public DateTime LastCheckDay { get; set; }

    public CardInfo(string title, string description, DateTime nextDay, DateTime lastDay)
    {
        Title = title;
        Description = description;
        this.CheckDay = nextDay;
        this.LastCheckDay = lastDay;
    }

    public CardInfo(string title, string description)
    {
        Title = title;
        Description = description;
        this.CheckDay = DateTime.Today.AddDays(1);
        this.LastCheckDay = DateTime.Today;
    }
}