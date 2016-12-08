using System;
using searchURLGetList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchURL 
{
    class Program 
    {
       // public static string userName { get; set; }

        static void Main(string[] args)
        {
           //  Prolog.stopWatchStart();
          //  Prolog.proLogStart();  //Starts text prolog

             Prolog.searchTermsStart(); // Starts manual input and search


            // SearchList.httpStreamRead();
            Prolog.stopWatchStart();
          // GetPeriod.getListFromFile(); //Gets our dino list from text file
                                         // GetPeriod.getListFromFile2();

            //Sorting.sortOrder();

           // GetBodyShape.runHttpStreamReadnshape();

            //Console.WriteLine("File loaded to list");

            //Console.WriteLine("Searching...");

            //GetPeriod.runHttpStreamRead(); // Runs GetPeriod to try and get Periods for our dinos

            //SeedListCheckTest.getdinosaurNames();
            //SeedListCheckTest.check();

            //GetDescription.runHttpStreamReadDescription();
            Prolog.stopWatchStop();
            Console.ReadLine();


        }
    }
}
