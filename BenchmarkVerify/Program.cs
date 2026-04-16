using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkVerify
{
    public class Program
    {
        private static readonly List<Chapter> Chapters = new()
        {
            new Chapter(1, "Arjuna Vishada Yoga", "Arjuna's inner turmoil and the crisis that leads to the teaching.")
            {
                Verses =
                {
                    new Verse(1, 1, "Dhritarashtra said: O Sanjaya, after assembling on the sacred field of Kurukshetra, what did my sons and the sons of Pandu do?")
                }
            },
            new Chapter(2, "Sankhya Yoga", "The path of wisdom, duty, and equanimity.")
            {
                Verses =
                {
                    new Verse(2, 47, "You have a right to perform your prescribed duty, but you are not entitled to the fruits of action.")
                }
            },
            new Chapter(3, "Karma Yoga", "The path of selfless action.")
            {
                Verses =
                {
                    new Verse(3, 19, "Therefore, without attachment, perform your duty, for by doing work without attachment one attains the Supreme.")
                }
            },
            new Chapter(4, "Jnana Karma Sanyasa Yoga", "Wisdom in action and devotion.")
            {
                Verses =
                {
                    new Verse(4, 7, "Whenever righteousness declines and unrighteousness rises, I manifest Myself.")
                }
            },
            new Chapter(6, "Dhyana Yoga", "The path of meditation.")
            {
                Verses =
                {
                    new Verse(6, 6, "The mind is a friend to the disciplined and an enemy to the undisciplined.")
                }
            },
            new Chapter(12, "Bhakti Yoga", "The path of devotion.")
            {
                Verses =
                {
                    new Verse(12, 13, "One who hates no creature, who is friendly and compassionate, is dear to Me.")
                }
            },
            new Chapter(18, "Moksha Sanyasa Yoga", "Liberation through renunciation and surrender.")
            {
                Verses =
                {
                    new Verse(18, 66, "Abandon all varieties of duty and surrender unto Me alone. I shall deliver you from all sins; do not fear.")
                }
            }
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Bhagwat Geeta Companion App");
            Console.WriteLine("----------------------------");

            bool running = true;
            while (running)
            {
                ShowMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListChapters();
                        break;
                    case "2":
                        ShowVerse();
                        break;
                    case "3":
                        ShowRandomVerse();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option (1-4).\n");
                        break;
                }
            }

            Console.WriteLine("Thank you for reflecting with the Bhagwat Geeta. Goodbye!");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. List highlighted chapters");
            Console.WriteLine("2. Read a verse");
            Console.WriteLine("3. Read a random verse");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
        }

        private static void ListChapters()
        {
            Console.WriteLine("\nHighlighted Chapters:");
            foreach (Chapter chapter in Chapters)
            {
                Console.WriteLine($"{chapter.Number}. {chapter.Title} - {chapter.Theme}");
            }
        }

        private static void ShowVerse()
        {
            Console.Write("\nEnter chapter number: ");
            if (!int.TryParse(Console.ReadLine(), out int chapterNumber))
            {
                Console.WriteLine("Invalid chapter number.");
                return;
            }

            Console.Write("Enter verse number: ");
            if (!int.TryParse(Console.ReadLine(), out int verseNumber))
            {
                Console.WriteLine("Invalid verse number.");
                return;
            }

            Chapter? chapter = Chapters.FirstOrDefault(c => c.Number == chapterNumber);
            if (chapter == null)
            {
                Console.WriteLine("Chapter not found in the highlighted list.");
                return;
            }

            Verse? verse = chapter.Verses.FirstOrDefault(v => v.Number == verseNumber);
            if (verse == null)
            {
                Console.WriteLine("Verse not found in the highlighted list.");
                return;
            }

            PrintVerse(verse);
        }

        private static void ShowRandomVerse()
        {
            List<Verse> allVerses = Chapters.SelectMany(c => c.Verses).ToList();
            Verse randomVerse = allVerses[new Random().Next(allVerses.Count)];
            PrintVerse(randomVerse);
        }

        private static void PrintVerse(Verse verse)
        {
            Console.WriteLine($"\nChapter {verse.ChapterNumber}, Verse {verse.Number}:");
            Console.WriteLine(verse.Text);
        }
    }

    public class Chapter
    {
        public Chapter(int number, string title, string theme)
        {
            Number = number;
            Title = title;
            Theme = theme;
            Verses = new List<Verse>();
        }

        public int Number { get; }
        public string Title { get; }
        public string Theme { get; }
        public List<Verse> Verses { get; set; }
    }

    public class Verse
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
    }
}
