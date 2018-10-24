using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MVCApp.Models
{
    public class PersonOfTheYear
    {
        //Properties of each PersonOfTheYear
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// Gets the list of people within begYear and endYear
        /// </summary>
        /// <param name="begYear">Beginning Year</param>
        /// <param name="endYear">Ending Year</param>
        /// <returns>List of PersonOfTheYear objects within begYear and endYear</returns>
        public static List<PersonOfTheYear> GetPersons(int begYear, int endYear)
        {
            //Creates a collection of PersonOfTheYear instances to be populated by data
            List<PersonOfTheYear> people = new List<PersonOfTheYear>();

            //Gets current working directory
            string path = Environment.CurrentDirectory;

            //Joins current directory with .csv path.
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));

            //Reads through the file and stores every line(data) into an array
            string[] myData = File.ReadAllLines(newPath);

            //Loops through the read data and skips the first line
            for (int i = 1; i < myData.Length; i++)
            {
                //Separate each individual line by commas into an array.
                string[] fields = myData[i].Split(',');

                //Add new instance of PersonOfTheYear to people list with corresponding data.
                people.Add(new PersonOfTheYear
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8]
                });
            }

            //Filters the list of people that fits within the begYear - endYear criteria
            List<PersonOfTheYear> listOfPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();

            //Returns the filtered list
            return listOfPeople;
        }
    }
}
