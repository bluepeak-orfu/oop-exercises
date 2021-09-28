using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class Movie
    {
        private string _title;
        private int _seenCount;
        public Movie(string title)
        {
            _title = title;
            _seenCount = 0;
        }

        public void PersonSeenMovie()
        {
            _seenCount++;
        }

        public string DescribeMovie() => $"The movie is called {_title} and has been seen by {_seenCount} people";
    }
}
