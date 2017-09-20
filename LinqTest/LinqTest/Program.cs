using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    internal class Person
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public int Age { get; set; }
        public string  DeathIndicator { get; set; }
    }

    class Program
    {
        static IList<string> givenNamePicker = new List<string> { "Marcell", "Evangeline", "Wade", "Rosita", "Donita", "Shanti", "Grady", "Ike", "Elida", "Machelle", "Caroline", "Nelle", "Lashawnda", "Emerson", "Sheba", "Chrissy", "Johanna", "Lita", "Eugene", "Nigel", "Regine", "Shayne", "Kori", "Natasha", "Samella", "Hunter", "Margie", "Darren", "Loise", "June", "Rachelle", "Isabell", "Tisha", "Mignon", "Maryann", "Normand", "Golda", "Robyn", "Anika", "Scottie", "Barrett", "Wilmer", "Raelene", "Ninfa", "Marquis", "Taina", "Sook", "Twyla", "Yee", "Anitra " };
        static IList<string> familyNamePicker = new List<string> { "Number", "Shavers", "Ryan", "Meneely", "Drum", "Thrash", "Kress", "Gatlin", "Lucero", "Henderson", "Barnard", "Kocsis", "Struble", "Lubin", "Zeller", "Schleusner", "Loughran", "Hennig", "Allshouse", "Carranco", "Straughan", "Modesto", "Amavisca", "Stanislawski", "Whitesel", "Fishman", "Dang", "Thome", "Dacruz", "Stilts", "Kline", "Cressman", "Washer", "Carrithers", "Vaquera", "Bocanegra", "Wojcik", "Pacifico", "Burkhard", "Perron", "Stoker", "Dawn", "Chagnon", "Nutt", "Nguyen", "Butz", "Lamons", "Saint", "Quintero", "Barrus" };
        static IList<string> deathIndicatorPicker = new List<string> { "Y", "N"  };
        static void Main(string[] args)
        {
            var people = GeneratePerson(100);

            int whereHitCount = 0;
            int selectHitCount = 0;
            int sortHitCount = 0;
            var filteredPeople = people.Where(p => {
                whereHitCount++; return ((p.FamilyName.Length % 2) == 0);
            }).OrderBy(p => {
                sortHitCount++; return p.Age;
            }).
            Select(p => {
                selectHitCount++; return p;
            }).ToList();

            Console.WriteLine("whereHitCount: {0}", whereHitCount);
            Console.WriteLine("sortHitCount: {0}", sortHitCount);
            Console.WriteLine("selectHitCount: {0}", selectHitCount);
            //Console.WriteLine("Filtered Ppl Count: {0}", filteredPeople.Count);
        }

        private static IEnumerable<Person>  GeneratePerson(int count)
        {
            var randomNumberPicker = new Random(0);
            var people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                people.Add(new Person {
                    DeathIndicator = deathIndicatorPicker[randomNumberPicker.Next(deathIndicatorPicker.Count)],
                    Age = randomNumberPicker.Next(60) + 1,
                    FamilyName = familyNamePicker[randomNumberPicker.Next(familyNamePicker.Count)],
                    GivenName = givenNamePicker[randomNumberPicker.Next(givenNamePicker.Count)]
                });
            }
            return people;
        }
    }
}
