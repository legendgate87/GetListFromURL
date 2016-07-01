using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    public class GetPeriod
    {
        public static string href = "http://www.nhm.ac.uk/discover/dino-directory/";
        //public static string href = "https://en.wikipedia.org/wiki/";
        public static string localAppPath = AppDomain.CurrentDomain.BaseDirectory;





        public static List<string> dinosaurNameAppended = new List<string>();
        public static List<string> dinosaurShapes = new List<string>();
        public static List<string> dinosaurPeriod = new List<string>();
        public static List<string> dinosaurPeriodNotFound = new List<string>();
        public static List<string> dinosaurDescription = new List<string>();
        public static List<string> dinosaurNames = new List<string>();
        public static List<string> dinoUrls = new List<string>();
        public static List<string> dinShapesFileGet = new List<string>();




        public static string logPath = $"{AppDomain.CurrentDomain.BaseDirectory}DinoList20160418.txt";



        //----------------------------------------------------------------------------------        
        
        public static void getListFromFile()
        {

            using (var sr = new StreamReader(logPath))
            {
                while (sr.Peek() >= 0)
                    
                    dinosaurNames.Add(sr.ReadLine());
            }
            Console.WriteLine(dinosaurNames.Count());

            // foreach (var item in dinosaurNames)
            // {
            //    // Console.WriteLine($"Index {pos}:  {dinosaurNames[pos]}...");
            //    // pos++;
            //    //// System.Threading.Thread.Sleep(50);
            // }
        }


        //public static void getListFromFile2()
        //{

        //    using (var sr = new StreamReader(logPath))
        //    {
        //        while (sr.Peek() >= 0)
        //            dinosaurNameAppended.Add(sr.ReadLine());
        //    }



        //}




        //-----------------------------------------------------------------------------------------------------

        public static string pageContent { get; set; }


        public static string searchIndexOfA = "<b><a href=\"dinosaur_facts_timeline_cretaceous.php\">";
        //public static string searchIndexOfA1 = "<small>Temporal range: <span style=\"display:inline-block;\">";
        //public static string searchIndexOfA2 = "<small>Temporal range: mid <a href=\"/wiki/";
        //public static string searchIndexOfA3 = ", a lizard-like reptile common to the Bristol";
        //public static string searchIndexOfA4 = "<small>Temporal range: Late <a href=\"/wiki/";
        //public static string searchIndexOfA5 = "<small>Temporal range: Santonian-Campanian <a href=\"/wiki/";

        public static string searchIndexOfB = "</a>";
        //public static string searchIndexOfB1 = "<";
        //public static string searchIndexOfB2 = " b";



        public static int pos = 0;

        //---------------------------------------------------------------------------------------------

        public static void runHttpStreamRead()
        {
            DateTime Now = DateTime.Now;

            //   string tempPath = Path.GetTempPath(); // C:\Users\UserName\AppData\Local\Temp\


            foreach (var item in dinosaurNames)
            {
                httpStreamRead();

            }

            //Parallel.ForEach(dinosaurNames, item =>
            //{
            //    httpStreamRead();
            //});

            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("DinoList END");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"dinosaurNames: {dinosaurNames.Count()}");
            Console.WriteLine($"dinosaurPeriod: {dinosaurPeriod.Count()}");

            Console.WriteLine($"dinosaurPeriodNotFound: {dinosaurPeriodNotFound.Count()}");
            
            File.WriteAllLines($"{localAppPath}SearchURL-GetPeriod{Now.ToString("yyyyMMdd")}.txt", dinosaurPeriod);
            File.WriteAllLines($"{localAppPath}SearchURL-PeriodsNotFound{Now.ToString("yyyyMMdd")}.txt", dinosaurPeriodNotFound);
            File.WriteAllLines($"{localAppPath}SearchURL-dinosaurNameAppended{Now.ToString("yyyyMMdd")}.txt", dinosaurNameAppended);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Number of dinosaur period Not Found: {dinosaurPeriodNotFound.Count()}");
            
            


            //Save to AppDomain.CurrentDomain.BaseDirectory or temPath 

            
        }

        //--------------------------------------------------------------------------------------------

        public static void httpStreamRead()
        {

            Console.WriteLine("-------------------------------------");
            dinosaurPeriod.ForEach(Console.WriteLine);
            Console.WriteLine("-------------------------------------");

            //  StreamWriter sw = new StreamWriter($"{tempPath}SearchURLGetPeriod-Temp.txt");

            Console.WriteLine(pos);

            var urlAdd = dinosaurNames[pos].ToLower().Trim();


            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(href + urlAdd + ".html");
            Console.WriteLine(href + urlAdd + ".html");
            HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();

             StreamReader sr = new StreamReader(myres.GetResponseStream());
            
            

            //while (sr.Peek() > -1)
            

            sr.GetLifetimeService();

            


    
            while (!sr.EndOfStream)
            {
                
                
                //pageContent = sr.ReadLine();
                pageContent = sr.ReadToEnd();



                 if (pageContent.Contains("Late") && pageContent.Contains("Triassic"))
                {
                    dinosaurPeriod.Add("Late Triassic");
                    break;
                }
                 if (pageContent.Contains("Early") && pageContent.Contains("Triassic"))
                {
                    dinosaurPeriod.Add("Early Triassic");
                    break;
                }

                 if (pageContent.Contains("Late") && pageContent.Contains("Jurassic"))
                {
                    dinosaurPeriod.Add("Late Jurassic");
                    break;
                }
                 if (pageContent.Contains("Early") && pageContent.Contains("Jurassic"))
                {
                    dinosaurPeriod.Add("Early Jurassic");
                    break;
                }

                 if (pageContent.Contains("Late") && pageContent.Contains("Cretaceous"))
                {
                    dinosaurPeriod.Add("Late Cretaceous");
                    break;
                }
                 if (pageContent.Contains("Early") && pageContent.Contains("Cretaceous"))
                {
                    dinosaurPeriod.Add("Early Cretaceous");
                    break;
                }

                 if (pageContent.Contains("Triassic"))
                {
                    dinosaurPeriod.Add("Triassic");
                    break;
                }
                 if (pageContent.Contains("Jurassic"))
                {
                    dinosaurPeriod.Add("Jurassic");
                    break;

                }
                 if (pageContent.Contains("Cretaceous"))
                {
                    dinosaurPeriod.Add("Cretaceous");
                    break;

                }
                else
                {
                    
                    dinosaurPeriod.Add("NOT FOUND");
                    dinosaurPeriodNotFound.Add(dinosaurNames[pos]);

                    break;
                }
                


                //if (pageContent.Contains(searchIndexOfA))
                //{

                //    string s = pageContent;



                //        int start = s.IndexOf(searchIndexOfA) + searchIndexOfA.Count();

                //    int end = s.IndexOf(searchIndexOfB, start);

                //    string result = s.Substring(start, end - start);

                //    if (result.Contains("_"))
                //    {

                //       result = result.Replace("_", " ");

                //    }


                //    if (result.Contains(";") || result.Contains("#") || result.Contains("&")) // Checks to see if the current list element is null or empty, if it is we know that we did not get a period
                //    {

                //        dinosaurNameAppended.Remove(dinosaurNames[pos]);

                //    }
                //    else { //Else we found a period and adds it to our list

                //        Console.WriteLine($"{result}");
                //        // sw.WriteLine(pageContent);

                //        Console.WriteLine("-----------------------------");

                //        //string playerDino = tolower;

                //        Console.WriteLine($"Found {dinosaurNames[pos]} {result}"); //  Alerts user that we found what they are searching for
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine();
                //        dinosaurPeriod.Add(result);
                //        dinosaurPeriod.Add(dinosaurNames[pos] + "                               " + result);


                //    }
                //}


                //else if (pageContent.Contains(searchIndexOfA1))
                //{
                //    string s = pageContent;


                //    int start = s.IndexOf(searchIndexOfA1) + searchIndexOfA1.Count();

                //    int end = s.IndexOf(searchIndexOfB1, start);

                //    string result = s.Substring(start, end - start);

                //    if (result.Contains("_"))
                //    {


                //        result = result.Replace("_", " ");
                //    }


                //    if (result.Contains(";") || result.Contains("#") || result.Contains("&"))  // Checks to see if the current list element is null or empty, if it is we know that we did not get a period
                //    {


                //        dinosaurNameAppended.Remove(dinosaurNames[pos]);

                //    }
                //    else { //Else we found a period and adds it to our list

                //        Console.WriteLine($"{result}");
                //        // sw.WriteLine(pageContent);

                //        Console.WriteLine("-----------------------------");

                //        //string playerDino = tolower;

                //        Console.WriteLine($"Found {result}"); //  Alerts user that we found what they are searching for
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine();
                //        dinosaurPeriod.Add(dinosaurNames[pos] + "                               " + result);


                //    }

                //}
                //else if (pageContent.Contains(searchIndexOfA2))
                //{
                //    string s = pageContent;


                //    int start = s.IndexOf(searchIndexOfA2) + searchIndexOfA2.Count();

                //    int end = s.IndexOf(searchIndexOfB, start);

                //    string result = s.Substring(start, end - start);

                //    if (result.Contains("_"))
                //    {


                //        result = result.Replace("_", " ");
                //    }


                //    string Mid = "Mid ";
                //    if (result.Contains(";") || result.Contains("#") || result.Contains("&")) // Checks to see if the current list element is null or empty, if it is we know that we did not get a period
                //    {

                //        dinosaurNameAppended.Remove(dinosaurNames[pos]);

                //    }
                //    else { //Else we found a period and adds it to our list

                //        Console.WriteLine($"{Mid + result}");
                //        // sw.WriteLine(pageContent);

                //        Console.WriteLine("-----------------------------");

                //        //string playerDino = tolower;

                //        Console.WriteLine($"Found {Mid + result}"); //  Alerts user that we found what they are searching for
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine();
                //        dinosaurPeriod.Add(dinosaurNames[pos] + "                               " + Mid + result);


                //    }
                //}
                //else if (pageContent.Contains(searchIndexOfA3))
                //{
                //    string s = pageContent;


                //    int start = s.IndexOf(searchIndexOfA3) + searchIndexOfA3.Count();

                //    int end = s.IndexOf(searchIndexOfB2, start);

                //    string result = s.Substring(start, end - start);

                //    if (result.Contains("_"))
                //    {


                //        result = result.Replace("_", " ");
                //    }


                //    if (result.Contains(";") || result.Contains("#") || result.Contains("&"))  // Checks to see if the current list element is null or empty, if it is we know that we did not get a period
                //    {


                //        dinosaurNameAppended.Remove(dinosaurNames[pos]);
                //    }
                //    else { //Else we found a period and adds it to our list

                //        Console.WriteLine($"{result}");
                //        // sw.WriteLine(pageContent);

                //        Console.WriteLine("-----------------------------");

                //        //string playerDino = tolower;

                //        Console.WriteLine($"Found {result}"); //  Alerts user that we found what they are searching for
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine();
                //        dinosaurPeriod.Add(dinosaurNames[pos] + "                               " + result);


                //    }
                //}
                //else if (pageContent.Contains(searchIndexOfA4))
                //{

                //    string s = pageContent;


                //    int start = s.IndexOf(searchIndexOfA4) + searchIndexOfA4.Count();

                //    int end = s.IndexOf(searchIndexOfB, start);

                //    string result = s.Substring(start, end - start);

                //    if (result.Contains("_"))
                //    {


                //        result = result.Replace("_", " ");
                //    }


                //    string Late = "Late ";

                //    if (result.Contains(";") || result.Contains("#") || result.Contains("&"))// Checks to see if the current list element is null or empty, if it is we know that we did not get a period
                //    {

                //        dinosaurNameAppended.Remove(dinosaurNames[pos]);

                //    }
                //    else { //Else we found a period and adds it to our list

                //        Console.WriteLine($"{Late + result}");
                //        // sw.WriteLine(pageContent);

                //        Console.WriteLine("-----------------------------");

                //        //string playerDino = tolower;

                //        Console.WriteLine($"Found {Late + result}"); //  Alerts user that we found what they are searching for
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine();
                //        dinosaurPeriod.Add(dinosaurNames[pos] + "                               " + Late + result);


                //    }
                //}
                //else if (pageContent.Contains(searchIndexOfA5))
                //{
                //    string s = pageContent;


                //    int start = s.IndexOf(searchIndexOfA5) + searchIndexOfA5.Count();

                //    int end = s.IndexOf(searchIndexOfB, start);

                //    string result = s.Substring(start, end - start);

                //    if (result.Contains("_"))
                //    {


                //        result = result.Replace("_", " ");
                //    }


                //    if (result.Contains(";") || result.Contains("#") || result.Contains("&")) // Checks to see if the current list element is null or empty, if it is we know that we did not get a period
                //    {

                //        dinosaurNameAppended.Remove(dinosaurNames[pos]);

                //    }
                //    else { //Else we found a period and adds it to our list

                //        Console.WriteLine($"{result}");
                //        // sw.WriteLine(pageContent);

                //        Console.WriteLine("-----------------------------");

                //        //string playerDino = tolower;

                //        Console.WriteLine($"Found {result}"); //  Alerts user that we found what they are searching for
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine("On Row: " + count);  // And the specific row we found it on
                //        Console.WriteLine("-----------------------------");
                //        Console.WriteLine();
                //        dinosaurPeriod.Add(dinosaurNames[pos] + "                               " + result);



                //    }
                //}




            }
            sr.Close();
            //System.Threading.Thread.Sleep(1000);
            Console.Clear();
            pos++;
            

            Console.WriteLine($"Done with dinoIndex: {pos}");
            //System.Threading.Thread.Sleep(1000);
                    
                }
            }
        }