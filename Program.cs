using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadCsvFileIntoArray(5);
            //ReadCsvFileIntoList();
            //ReadCsvFileIntoDictionary("BRA");
            ReadCsvFileIntoDictionary();
        }

        public static void ArrayOfDays()
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thrusday",
                "Friday",
                "Sarturday",
                "Sunday"
            };

            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
        }

        public static CsvReader StartCsv(string filePath)
        {
            CsvReader reader = new CsvReader(filePath);
            return reader;
        }

        public static void ReadCsvFileIntoArray(int numberOfCountries)
        {
            CsvReader reader = StartCsv(@"../../../WorldPopulation.csv");

            Country[] coutries = reader.ReadNCountriesToArray(numberOfCountries);

            foreach (Country country in coutries)
            {
                Console.WriteLine($"{country.Population}:{country.Name}");
            }
        }

        public static void ReadCsvFileIntoDictionary(string requestedString = null)
        {
            CsvReader reader = StartCsv(@"../../../WorldPopulation.csv");

            Dictionary<string, Country> coutries = reader.ReadCountriesToDictionary();

            if (requestedString != null)
            {
                //single registry by key
                var RequestedCountry = coutries[requestedString];
                Console.WriteLine($"{RequestedCountry.Population}:{RequestedCountry.Name}");
            }
            else
            {
                //all registries
                foreach (var country in coutries.Values)
                {
                    Console.WriteLine($"{country.Population}:{country.Name}");
                }
            }
        }

        public static void ReadCsvFileIntoList()
        {
            CsvReader reader = StartCsv(@"../../../WorldPopulation.csv");

            List<Country> coutries = reader.ReadCountriesToList();

            foreach (Country country in coutries)
            { 
                Console.WriteLine($"{country.Population}:{country.Name}");
            }
        }
    }
}