using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.BehaviorPatterns
{
    /// <summary>
    /// This pattern basically is to build an Iterator with public methods to access elements of a collection.
    /// The example blow is to build a music track player. The PlayerController here acts as the Iterator, to grab all the tracks of the playlist, and control the track to play.
    /// </summary>
    public class IteratorPattern : IDesignPatternExample
    {
        public void Execute()
        {
            Console.WriteLine("IteratorPattern");

            TrackPlayer<Track> trackPlayer = new TrackPlayer<Track>();
            GenerateTracks(trackPlayer);
            
            PlayerController<Track> playerController = trackPlayer.CreatePlayerController();

            Console.WriteLine("Tracks:");
            while (!playerController.IsLast())
                playerController.Play();

            Console.WriteLine("Play first");
            playerController.First();
            playerController.Play();

            Console.WriteLine("Play last");
            playerController.Last();
            playerController.Play();

            Console.ReadLine();
        }

        private void GenerateTracks(TrackPlayer<Track> trackPlayer)
        {
            var tracks = Enumerable.Range(1, 10).Select(number => new Track("Track " + number)).ToList();
            for (int i = 0; i < tracks.Count(); i++)
                trackPlayer[i] = tracks[i];
        }
    }

    
    public class Track
    {
        private string _name;

        public string Name { get { return _name; } }

        public Track(string name)
        {
            _name = name;
        }
    }

    public interface IAbstractIterator<T> where T : class
    {
        T First();
        T Last();
        T Next();
        T Previous();
        T CurrentItem();

        bool IsLast();
    }

    public interface IAbstractCollection<T> where T: class
    {
        Iterator<T> CreateIterator();
    }

    public class Iterator<T> : IAbstractIterator<T> where T: class
    {
        private Collection<T> _collection;
        private int _current = 0;

        public Iterator(Collection<T> collection)
        {
            _collection = collection;
        }

        public T CurrentItem()
        {
            return _collection[_current] as T;
        }

        public T First()
        {
            _current = 0;
            return _collection[_current] as T;
        }

        public T Last()
        {
            _current = _collection.Count() - 1;
            return _collection[_current] as T;
        }

        public T Next()
        {
            _current++;
            if (IsLast()) return null;
            return _collection[_current] as T;
        }

        public T Previous()
        {
            _current--;
            return _collection[_current] as T;
        }

        public bool IsLast()
        {
            return _current >= _collection.Count() - 1;
        }
    }

    public class PlayerController<T> : Iterator<T> where T: Track
    {
        public PlayerController(Collection<T> collection) : base(collection)
        {
        }

        public void Play()
        {
            var currentTrack = CurrentItem(); ;
            if (currentTrack == null)
            {
                Console.WriteLine("End of playlist");
                return;
            }

            Console.WriteLine("Playing track: " + currentTrack.Name);
            Next();
        }
    }

    public class Collection<T> : IAbstractCollection<T> where T: class
    {
        private List<T> _items = new List<T>(); 

        public Iterator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }

        public int Count() { return _items.Count; }
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add((T)value); }
        }
    }

    public class TrackPlayer<T> : Collection<T> where T: Track
    {
        public PlayerController<T> CreatePlayerController()
        {
            return new PlayerController<T>(this);
        }
    }
}
