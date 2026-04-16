namespace BhagwatGeetaApp.Models;

public sealed class Verse
{
    public Verse(int chapterNumber, int number, string text)
    {
        ChapterNumber = chapterNumber;
        Number = number;
        Text = text;
    }

    public int ChapterNumber { get; }
    public int Number { get; }
    public string Text { get; }

    public string DisplayTitle => $"Verse {Number}";
}
