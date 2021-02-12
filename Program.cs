using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  string[] daysOfWeek =
              {
                  "Monday",
                  "Tuesday",
                  "Wednesday",
                  "Thursday",
                  "Friday",
                  "Saturday",
                  "Sunday"
              };
              foreach (string day in daysOfWeek)
              {
                  Console.WriteLine($"Days of week are: {day}");
                  Console.ReadKey();

              }
              */
            string filePath = @"C:\Mirjana Vaje\C#\WorldPopulation\Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);
            List<Country> countries = reader.ReadAllCountries();

            Console.Write("Enter number of countries to display: ");
           bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            if(!inputIsInt || userInput<= 0)
            {
                Console.WriteLine("You must type in integer.");
                return;

            }
            int maxToDisplay = Math.Min(userInput, countries.Count);
            for (int i=0; i< userInput; i++)  
            {
                Country country = countries[i];
                Console.WriteLine($"{PopulationFormater.FormatPopulation(country.Population).PadLeft(15)}:{country.Name}");
            }

            Country jackuruku = new Country("Jackuruku", "Jac", "Marliland", 2000000);
            int jackurukuIndex= countries.FindIndex(x=>x.Population< 2000000) ;
            countries.Insert(jackurukuIndex, jackuruku);

            //foreach(Country country in countries)
            //{
            //    Console.WriteLine($"{PopulationFormater.FormatPopulation(country.Population).PadLeft(15)}:{country.Name}");
                
            //}
            //Console.WriteLine($"{countries.Count} countries");
            Console.ReadLine();
        }
    }
}
