using System;

public class CardInfo
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CheckDay { get; set; }
    public int Box { get; set; }

    public CardInfo(string title, string description, DateTime nextDay, int box)
    {
        Title = title;
        Description = description;
        this.CheckDay = nextDay;
        this.Box = box;
    }

    public CardInfo(string title, string description)
    {
        Title = title;
        Description = description;
        this.CheckDay = DateTime.Today.AddDays(1);
        this.Box = 1;
    }
}