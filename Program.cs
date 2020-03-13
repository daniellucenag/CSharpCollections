using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadCsvFileIntoArray(5);
            ReadCsvFileIntoList();
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

            Country[] coutries = reader.ReadFirstNCountries(numberOfCountries);

            foreach (Country country in coutries)
            {
                Console.WriteLine($"{country.Population}:{country.Name}");
            }
        }

        public static void ReadCsvFileIntoList()
        {
            CsvReader reader = StartCsv(@"../../../WorldPopulation.csv");

            List<Country> coutries = reader.ReadAllCountries();

            foreach (Country country in coutries)
            {
                Console.WriteLine($"{country.Population}:{country.Name}");
            }
        }
    }
}