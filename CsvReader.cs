using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpCollections
{
    public class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public Country[] ReadNCountriesToArray(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {  
                for (int i = 0; i < nCountries; i++)
                {
                    string csvLine = sr.ReadLine();
                    countries[i] = ReadCountryFromCsvLine(csvLine);
                }
            }

            return countries;
        }
        
        public List<Country> ReadCountriesToList()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            { 
                var line = sr.ReadLine();

                while (line != null)
                {
                    countries.Add(ReadCountryFromCsvLine(line));
                    line = sr.ReadLine();
                }
            }   

            return countries;
        }

        public Dictionary<string, Country> ReadCountriesToDictionary()
        {
            Dictionary<string, Country> countries = new Dictionary<string, Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                var line = sr.ReadLine();

                while (line != null)
                {
                    var country = ReadCountryFromCsvLine(line);

                    countries.Add(country.Code, country);
                    line = sr.ReadLine();
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(';');

            return new Country(
                parts[0],
                parts[1],
                parts[2],
                int.Parse(parts[3])
            );
                
        }
    }
}