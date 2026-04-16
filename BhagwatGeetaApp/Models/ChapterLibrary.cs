namespace BhagwatGeetaApp.Models;

public static class ChapterLibrary
{
    public static List<Chapter> HighlightedChapters { get; } = new()
    {
        new Chapter(
            1,
            "Arjuna Vishada Yoga",
            "Arjuna's inner turmoil and the crisis that leads to the teaching.",
            new List<Verse>
            {
                new(1, 1, "Dhritarashtra said: O Sanjaya, after assembling on the sacred field of Kurukshetra, what did my sons and the sons of Pandu do?")
            }),
        new Chapter(
            2,
            "Sankhya Yoga",
            "The path of wisdom, duty, and equanimity.",
            new List<Verse>
            {
                new(2, 47, "You have a right to perform your prescribed duty, but you are not entitled to the fruits of action."),
                new(2, 50, "A person of steady wisdom abandons the fruits of action and attains serenity.")
            }),
        new Chapter(
            3,
            "Karma Yoga",
            "The path of selfless action.",
            new List<Verse>
            {
                new(3, 19, "Therefore, without attachment, perform your duty, for by doing work without attachment one attains the Supreme."),
                new(3, 30, "Dedicate all actions to Me, with your mind on the Self, free from longing and selfishness.")
            }),
        new Chapter(
            4,
            "Jnana Karma Sanyasa Yoga",
            "Wisdom in action and devotion.",
            new List<Verse>
            {
                new(4, 7, "Whenever righteousness declines and unrighteousness rises, I manifest Myself."),
                new(4, 38, "In this world there is nothing so purifying as knowledge.")
            }),
        new Chapter(
            6,
            "Dhyana Yoga",
            "The path of meditation.",
            new List<Verse>
            {
                new(6, 6, "The mind is a friend to the disciplined and an enemy to the undisciplined."),
                new(6, 26, "Wherever the restless mind wanders, let the mind be brought back to the Self." )
            }),
        new Chapter(
            12,
            "Bhakti Yoga",
            "The path of devotion.",
            new List<Verse>
            {
                new(12, 13, "One who hates no creature, who is friendly and compassionate, is dear to Me."),
                new(12, 15, "That person who neither disturbs others nor is disturbed by others is dear to Me.")
            }),
        new Chapter(
            18,
            "Moksha Sanyasa Yoga",
            "Liberation through renunciation and surrender.",
            new List<Verse>
            {
                new(18, 65, "Fix your mind on Me, be devoted to Me, and you shall come to Me."),
                new(18, 66, "Abandon all varieties of duty and surrender unto Me alone. I shall deliver you from all sins; do not fear.")
            })
    };
}
