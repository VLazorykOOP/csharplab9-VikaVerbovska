using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab9Tasks
{
    // Клас Пісня
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"\"{Title}\" - {Artist}";
        }
    }

    // Клас Музичний Диск
    public class MusicDisc
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

        public MusicDisc(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public void RemoveSong(string title)
        {
            Songs.RemoveAll(s => s.Title == title);
        }

        public override string ToString()
        {
            string result = $"Диск: {Name}\n";
            foreach (var song in Songs)
                result += $"  - {song}\n";
            return result;
        }
    }

    // Головний клас з Hashtable
    public class MusicCatalog
    {
        private Hashtable catalog = new Hashtable();

        // Додавання диска
        public void AddDisc(string discName)
        {
            if (!catalog.ContainsKey(discName))
                catalog.Add(discName, new MusicDisc(discName));
        }

        // Видалення диска
        public void RemoveDisc(string discName)
        {
            if (catalog.ContainsKey(discName))
                catalog.Remove(discName);
        }

        // Додавання пісні
        public void AddSongToDisc(string discName, Song song)
        {
            if (catalog.ContainsKey(discName))
                ((MusicDisc)catalog[discName]).AddSong(song);
        }

        // Видалення пісні
        public void RemoveSongFromDisc(string discName, string title)
        {
            if (catalog.ContainsKey(discName))
                ((MusicDisc)catalog[discName]).RemoveSong(title);
        }

        // Перегляд усього каталогу
        public void ShowAll()
        {
            Console.WriteLine("=== Каталог ===");
            foreach (DictionaryEntry entry in catalog)
            {
                Console.WriteLine(entry.Value.ToString());
            }
        }

        // Перегляд одного диска
        public void ShowDisc(string discName)
        {
            if (catalog.ContainsKey(discName))
                Console.WriteLine(catalog[discName].ToString());
            else
                Console.WriteLine("Диск не знайдено.");
        }

        // Пошук по виконавцю
        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"=== Пошук пісень виконавця: {artist} ===");
            foreach (DictionaryEntry entry in catalog)
            {
                MusicDisc disc = (MusicDisc)entry.Value;
                foreach (var song in disc.Songs)
                {
                    if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{disc.Name}: {song}");
                    }
                }
            }
        }
    }

    public class Lab9T4
    {
        public void Run()
        {
            MusicCatalog catalog = new MusicCatalog();

            catalog.AddDisc("Rock Hits");
            catalog.AddDisc("Pop Stars");

            catalog.AddSongToDisc("Rock Hits", new Song("Bohemian Rhapsody", "Queen"));
            catalog.AddSongToDisc("Rock Hits", new Song("Stairway to Heaven", "Led Zeppelin"));
            catalog.AddSongToDisc("Pop Stars", new Song("Bad Romance", "Lady Gaga"));
            catalog.AddSongToDisc("Pop Stars", new Song("Thriller", "Michael Jackson"));

            catalog.ShowAll();

            Console.WriteLine("\n>>> Видаляємо пісню 'Thriller' з 'Pop Stars':");
            catalog.RemoveSongFromDisc("Pop Stars", "Thriller");

            catalog.ShowDisc("Pop Stars");

            Console.WriteLine("\n>>> Пошук пісень виконавця 'Queen':");
            catalog.SearchByArtist("Queen");
        }
    }
}
