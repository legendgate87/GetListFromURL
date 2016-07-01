using searchURL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchURLGetList
{
    class SeedListCheckTest
    {

       public static Random rand = new Random();

        public static string logPath2 = $"C:\\Users\\deltagare\\OneDrive\\Lexicon\\Visual studio\\Foxtrot\\Foxtrot\\bin\\Description.txt";
        public static string logPath3 = $"C:\\Users\\deltagare\\OneDrive\\Lexicon\\Visual studio\\Foxtrot\\Foxtrot\\bin\\Period.txt";
        public static string logPath4 = $"C:\\Users\\deltagare\\OneDrive\\Lexicon\\Visual studio\\Foxtrot\\Foxtrot\\bin\\DinoList.txt";

        public static List<string> dinosaurDiet = new List<string>();





        

        public static void getdinosaurNames()
        {

            using (var sr = new StreamReader(logPath2))
            {
                while (sr.Peek() >= 0)
                    dinosaurDiet.Add(sr.ReadLine());
            }
            using (var sr = new StreamReader(logPath3))
            {
                while (sr.Peek() >= 0)
                    GetPeriod.dinosaurPeriod.Add(sr.ReadLine());
            }
            using (var sr = new StreamReader(logPath4))
            {
                while (sr.Peek() >= 0)
                    GetPeriod.dinosaurNames.Add(sr.ReadLine());
            }

        }

       public static void check()
        {

        

        string Carn = "Carnivore";
        string Herb = "Herbivore";
        string Omni = "Omnivore";

           int DietNew = 0;
            int pos = 0;



            foreach (var item in dinosaurDiet)
            {
                dinosaurDiet.Count();



                Console.WriteLine("RANDOM: " + rand.Next(1, 3));
                Console.WriteLine("Names" + GetPeriod.dinosaurNames.Count() +
                    "Period" + GetPeriod.dinosaurPeriod.Count() +
                    "Diet" + dinosaurDiet.Count()
              );

                if (dinosaurDiet[pos].Contains(Carn))
                {

                    DietNew = 1;
                }
                else if (dinosaurDiet[pos].Contains(Herb))
                {
                    DietNew = 2;
                }
                else if (dinosaurDiet[pos].Contains(Omni))
                {
                    DietNew = 3;
                }
                pos++;
                Console.WriteLine(DietNew);
                Console.WriteLine(pos);
                Console.ReadLine();

            }
        }
    }
}
