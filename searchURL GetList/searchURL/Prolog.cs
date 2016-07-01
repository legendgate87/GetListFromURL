using searchURL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchURLGetList
{
    class Prolog
    {

        public static Stopwatch stopWatch = new Stopwatch();

        public static void proLogStart()
        {

            Console.WriteLine("Terminal H-A-9");
            Console.WriteLine("");
            Console.WriteLine("User: *********");
            Console.WriteLine("");
            Console.WriteLine("Conecting to Cray-Core01...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("connection established...");
            Console.WriteLine("");
            Console.WriteLine("You are now useing InGen-data-link-1");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("System check...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Core OK...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Memory OK...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Conection OK...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Harddrive OK...");
            Console.WriteLine("");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("System Check done...");
            Console.WriteLine("");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Loading dinos from InGen list on file");
            Console.WriteLine("Stand by...");
            System.Threading.Thread.Sleep(5000);

            GetPeriod.getListFromFile();
            Console.WriteLine("done...");
            Console.WriteLine("");


            Console.WriteLine("System Ready");
            Console.WriteLine("");

        }

        public static void searchTermsStart()
        {
            var userPressHelp = Console.ReadKey().Key != ConsoleKey.F1;
            if (userPressHelp) { Help.helpUser(); }


            Console.WriteLine("Enter URL -- Don't forget http www . : / or .com etc");
            // Console.WriteLine("Press F1 for more help");

            SearchList.inputUrl = Console.ReadLine();
            Console.WriteLine("Enter search term");
            


            Console.WriteLine("Enter specific searchIndex term Start");
            SearchList.searchIndexOfA = Console.ReadLine();


            Console.WriteLine("Enter specific searchIndex term End");
            SearchList.searchIndexOfB = Console.ReadLine();

            // SearchList.dinosaurNames.ForEach(i => Console.Write("{0}\t", i));

            SearchList.httpStreamRead();

        }

        public static void stopWatchStart()
        {
            
            stopWatch.Start();
            
           
        }
        public static void stopWatchStop()
        {
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
