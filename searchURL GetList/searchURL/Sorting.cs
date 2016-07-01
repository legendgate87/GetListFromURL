using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    class Sorting : GetPeriod
    {
        public static void sortOrder() 
        {

            getListFromFile3();
            orderList();

        }


        static void getListFromFile3()
        {


            string logPath = $"{AppDomain.CurrentDomain.BaseDirectory}DinoShapes.txt";

            using (var sr = new StreamReader(logPath))
            {
                while (sr.Peek() >= 0)

                    dinosaurShapes.Add(sr.ReadLine());
               
            }

        }

        static void orderList()
        {
            DateTime Now = DateTime.Now;

            //var uniqueItems = new HashSet<string>(dinosaurShapes);

            var sortedlist = dinosaurShapes.OrderBy(x => x).ToList().Distinct();

            



            //var posi = 0;

            //while (posi != 307)
            //{

            //    if (dinosaurNames.Contains(dinosaurShapes[posi]))
            //    {
            //        dinosaurNames.Remove(dinosaurNames[posi]);

            //        Console.ReadLine();
            //    }
            //    posi++;

            //}



            Console.WriteLine("-------------------------------------");
            //sortedlist.ForEach(Console.WriteLine);
            Console.WriteLine("-------------------------------------");
            File.WriteAllLines($"{localAppPath}SearchURL-SortedDinosaurShapes{sortedlist.Count()}{Now.ToString("yyyyMMdd")}.txt", sortedlist);
            Console.WriteLine("");
            Console.WriteLine("Count sorteddinosaurShapes: " + sortedlist.Count());
            Console.WriteLine("Count dinosaurShapes: " + dinosaurShapes.Count());
            Console.WriteLine("");
        }

    }
}
