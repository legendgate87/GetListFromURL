using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    public class Search
    {
        public static List<string> periodList = new List<string>();

        public static string pageContent { get; set; }
        public static string inputString { get; set; }
        public static string searchIndexOfA { get; set; }
        public static string searchIndexOfB { get; set; }

        public static void httpStreamRead()
        {
            var fileStream = File.OpenWrite("C:\\Users\\deltagare\\OneDrive\\Temp\\streamDinoTemp3.txt");
            StreamWriter sw = new StreamWriter("C:\\Users\\deltagare\\OneDrive\\Temp\\streamDinoTemp4.txt");

            //  HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://www.dinodictionary.com/azdict_index.asp");
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://www.dinodictionary.com/dinos_a.asp");
            HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();

            StreamReader sr = new StreamReader(myres.GetResponseStream());




            //while (sr.Peek() > -1)
            int count = 0;
            int countIndex = 0;
            while (!sr.EndOfStream)
            {

                pageContent = sr.ReadLine();
                if (pageContent.IndexOf('<') >= 0)

                {

                    // Period: Early - Late Cretaceous

                    if (pageContent.Contains(periodList[countIndex]))
                    {
                        string s = pageContent;
                        //asp# , Period:
                        
                        int start = s.IndexOf(searchIndexOfA) + 4;
                        //\"
                        int end = s.IndexOf(searchIndexOfB, start);

                        string result = s.Substring(start, end - start);

                        Console.WriteLine(result);

                        //       dinosaurNames.Add(result);
                        sw.WriteLine(result);

                        //string playerDino = tolower;

                        //Console.WriteLine($"Found {searchString} In StreamReader Function!");
                        //Console.WriteLine("On Row: " + count);

                    }
                    //else
                    //{
                    //    Console.WriteLine("Not found no this row!");

                    //}
                }
                countIndex++;
                count++;










            }
            fileStream.Close();
            Console.ReadLine();
        }

    }
}