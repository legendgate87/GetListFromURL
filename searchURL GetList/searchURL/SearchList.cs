using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    public class SearchList
    {

        public static List<string> dinosaurNames = new List<string>();

        public static string pageContent { get; set; }

        public static string inputUrl = "http://www.dinodictionary.com/azdict_index.asp";


        public static string searchIndexOfA ="asp#";
        public static string searchIndexOfB = "\"";




        public static void httpStreamRead()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            DateTime Now = DateTime.Now;

            
           string tempPath = $"{AppDomain.CurrentDomain.BaseDirectory}DinoList{Now.ToString("yyyyMMdd")}.txt";

            //var fileStream = File.OpenWrite($"C:\\{Now.ToString("yyyyMMdd")}-{g}.txt");
            // StreamWriter sw = new StreamWriter($"C:\\{Now.ToString("yyyyMMdd")}-{g}.txt");
            //var sw = File.CreateText($"{tempPath}SearchURL-Temp{Now.ToString("yyyyMMdd")}.txt");
           
            var sw = File.CreateText($"{tempPath}");

            //http://www.dinodictionary.com/azdict_index.asp
            //https://en.wikipedia.org/wiki/List_of_dinosaur_genera

            if (inputUrl == null)
            { Console.WriteLine("URL is empty! cannot complete request..."); Console.ReadLine(); }

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(inputUrl);
            HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();

            StreamReader sr = new StreamReader(myres.GetResponseStream());




            //while (sr.Peek() > -1)
            int count = 0;
            while (!sr.EndOfStream)
            {

                pageContent = sr.ReadLine();
                if (pageContent.IndexOf('<') >= 0)

                {

                    // Period: Early - Late Cretaceous
                    //pageContent.Contains(inputString ) || 
                    if (pageContent.Contains(searchIndexOfA))
                    {
                        string s = pageContent;
                        int start = s.IndexOf(searchIndexOfA) + searchIndexOfA.Count();

                        int end = s.IndexOf(searchIndexOfB, start);

                        string result = s.Substring(start, end - start);



                        dinosaurNames.Add(result);

                        sw.WriteLine(result);

                        Console.WriteLine("-----------------------------");
                        // sw.WriteLine(pageContent);
                        Console.WriteLine(pageContent);
                        Console.WriteLine("-----------------------------");



                        //string playerDino = tolower;

                        Console.WriteLine($"Found {result}"); //  Alerts user that we found what they are searching for
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                        Console.WriteLine("-----------------------------");

                    }

                }
                //   else
                //   {
                //       Console.WriteLine($"{inputString}Not found no this row! {count}");
                //
                //   }
                count++;

            }
            sw.Close();
            Console.ReadLine();
        }

    }
}