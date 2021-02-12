using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation
{
     class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }
        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>() ;

            using (StreamReader sr = new StreamReader(_csvFilePath)){
                // read header line

                sr.ReadLine();
                string csvLine;
                while((csvLine=sr.ReadLine())!=null)
                { 
                    countries.Add(ReadCountryFromCvsLine(csvLine));
                }
            }
            return countries;
        }

        

        public Country ReadCountryFromCvsLine(string csvLine)
        {
            string [] parts = csvLine.Split(',');

            string name ;
            string code ;
            string region;
            string popText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;

                case 5:
                name= parts[0] + "," + parts[1];//connect 
                    name = name.Replace("\"", null).Trim();//to remove "" Quotes
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country form csv file{csvLine}");
            }
            int.TryParse(popText, out int population);// TryParse leaves population 0 if can't parse
            
            return new Country(name, code, region, population);
        }
    }
}
