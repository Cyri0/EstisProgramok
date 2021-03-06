using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmek
{
    class Movie
    {
        public string revenue, vote_average, vote_count, title, original_language, release_date, production_companies, production_countries, genres, director, producer, cast, runtimes, writer;

        public Movie(string line) {
            string[] parts = line.Split(';');

            (revenue, vote_average, vote_count, title, original_language, release_date, production_companies, production_countries, genres, director, producer, cast, runtimes, writer) = (parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13]);
        }

        public override string ToString()
        {
            return this.title;
        }

        public List<string> getActors()
        {
            return this.cast.Split(',').ToList();
        }

        public bool containsActor(string actor)
        {
            foreach (string item in this.getActors())
            {
                if (item.ToUpper().Contains(actor.ToUpper()))
                    return true;
            }
            return false;
        }

        public int getYear()
        {
            // "2022"
            int year;
            try
            {
                year = int.Parse(this.release_date.Split('.')[0]);
            }
            catch (Exception)
            {
                year = 0;
            }

            return year;
        }
    }
}
