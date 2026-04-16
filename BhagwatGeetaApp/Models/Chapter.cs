namespace BhagwatGeetaApp.Models;

public sealed class Chapter
{
    public Chapter(int number, string title, string theme, List<Verse> verses)
    {
        Number = number;
        Title = title;
        Theme = theme;
        Verses = verses;
    }

    public int Number { get; }
    public string Title { get; }
    public string Theme { get; }
    public List<Verse> Verses { get; }

    public string DisplayTitle => $"{Number}. {Title}";
}
