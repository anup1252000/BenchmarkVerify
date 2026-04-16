using System;
using System.Collections.Generic;
using System.Linq;
using BhagwatGeetaApp.Models;

namespace BhagwatGeetaApp;

public partial class MainPage : ContentPage
{
    private readonly List<Chapter> _chapters;

    public MainPage()
    {
        InitializeComponent();

        _chapters = ChapterLibrary.HighlightedChapters;
        ChapterPicker.ItemsSource = _chapters.Select(chapter => chapter.DisplayTitle).ToList();

        if (_chapters.Count > 0)
        {
            ChapterPicker.SelectedIndex = 0;
        }
    }

    private void OnChapterChanged(object sender, EventArgs e)
    {
        if (ChapterPicker.SelectedIndex < 0)
        {
            return;
        }

        Chapter selectedChapter = _chapters[ChapterPicker.SelectedIndex];
        VersePicker.ItemsSource = selectedChapter.Verses.Select(verse => verse.DisplayTitle).ToList();
        VersePicker.SelectedIndex = selectedChapter.Verses.Count > 0 ? 0 : -1;
    }

    private void OnVerseChanged(object sender, EventArgs e)
    {
        if (ChapterPicker.SelectedIndex < 0 || VersePicker.SelectedIndex < 0)
        {
            return;
        }

        Chapter selectedChapter = _chapters[ChapterPicker.SelectedIndex];
        Verse selectedVerse = selectedChapter.Verses[VersePicker.SelectedIndex];
        UpdateVerseDisplay(selectedVerse);
    }

    private void OnRandomVerseClicked(object sender, EventArgs e)
    {
        List<Verse> allVerses = _chapters.SelectMany(chapter => chapter.Verses).ToList();
        if (allVerses.Count == 0)
        {
            return;
        }

        Verse randomVerse = allVerses[Random.Shared.Next(allVerses.Count)];
        ChapterPicker.SelectedIndex = _chapters.FindIndex(chapter => chapter.Number == randomVerse.ChapterNumber);
        if (ChapterPicker.SelectedIndex >= 0)
        {
            VersePicker.SelectedIndex = _chapters[ChapterPicker.SelectedIndex].Verses
                .FindIndex(verse => verse.Number == randomVerse.Number);
        }

        UpdateVerseDisplay(randomVerse);
    }

    private void UpdateVerseDisplay(Verse verse)
    {
        VerseReferenceLabel.Text = $"Chapter {verse.ChapterNumber}, Verse {verse.Number}";
        VerseTextLabel.Text = verse.Text;
    }
}
