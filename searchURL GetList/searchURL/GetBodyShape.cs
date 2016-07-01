using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    /// <summary>
    /// Search GET Dino Shapes
    /// </summary>
    public class GetBodyShape : GetPeriod
    {
        //Sauropod,ceratopian,euornithopod,large theropod,small theropod,ankylosaurid,ornithomimosaur

        public static string hrefShape = "";
        public static int pos2 = 0;
        private static bool  loop = true;

        //---------------------------------------------------------------------------------------------

        public static void runHttpStreamReadnshape()
        {
            Double Now = DateTime.Now.Millisecond;

            //   string tempPath = Path.GetTempPath(); // C:\Users\UserName\AppData\Local\Temp\



            string logPathLocal = $"{AppDomain.CurrentDomain.BaseDirectory}dinoUrls.txt";
            string logPathLocal2 = $"{AppDomain.CurrentDomain.BaseDirectory}dinShapesFileGet.txt";


        //--------------------------------------------------------------------------------------------
            using (var sr = new StreamReader(logPathLocal))
            {
                while (sr.Peek() >= 0)
                    dinoUrls.Add(sr.ReadLine());
            }

            using (var sr = new StreamReader(logPathLocal2))
            {
                while (sr.Peek() >= 0)
                    dinShapesFileGet.Add(sr.ReadLine());
            }

//------------------------------------------------------------------------------------------------------            
           while (loop == true)
                 {

                httpStreamReadShape();                
            }

            //Parallel.ForEach(dinosaurNames, item =>
            //{
            //    httpStreamReadShape();
            //});

            Console.WriteLine("\n--------------------------------\nDinoSearch END\n--------------------------------\n");

            var uniqueItems = new HashSet<string>(dinosaurShapes);

            var sortedlist = uniqueItems.OrderBy(x => x).ToList();
            File.WriteAllLines($"{localAppPath}DinoShapes.txt", dinosaurShapes);
        }
    

    //--------------------------------------------------------------------------------------------------------------------


    public static void httpStreamReadShape()
        {

            if (pos2 >= dinoUrls.Count())
            {
                loop = false;
                pos2 = 0;
                System.Threading.Thread.Sleep(10);

            }
            if (pos == dinosaurNames.Count())
            {
                pos = 0;
                pos2++;
            }

            Console.WriteLine($"\n-------------------------------------\nDinosaurs in dinosaurShapes: {dinosaurShapes.Count()}\n-------------------------------------\n");
            Console.WriteLine($"ON: {dinosaurNames[pos]}\nDone with dinoIndex: {pos}\nDinosaurNames in list: " + dinosaurNames.Count()+ "\nURL Position: " + pos2);
            
            try
            {
                string url = dinoUrls[pos2].ToString();

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
                Console.WriteLine($"\n-------------------------------------\n"+url);
                HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                StreamReader sr = new StreamReader(myres.GetResponseStream());


                sr.GetLifetimeService();
                string shape = "";
                string dinoName = dinosaurNames[pos].ToLower().Replace(" ", "");


                while (!sr.EndOfStream)
                {
                    //pageContent = sr.ReadLine();
                    pageContent = sr.ReadLine();
                    

                    //if (pageContent.Contains("        <a href=\"/discover/dino-directory/"))
                    //{
                    //    string pageContentNew = pageContent.ToString();

                    //    string newReplace1 = pageContentNew.Replace("        <a href=\"/discover/dino-directory/", " ");
                    //    string newReplace2 = newReplace1.Replace(".html\">", " ");
                    //    string newReplace3 = newReplace2.Replace("</a>", " ");

                    //    newReplace3 = newReplace3.Substring(newReplace3.IndexOf(' ') + newReplace3.Count() / 2);


                    //    //dinosaurNameAppended.Add(newReplace3);


                    //    //var uniqueItems = new HashSet<string>(dinosaurNameAppended);

                    //    //var sortedlist = uniqueItems.OrderBy(x => x).ToList();

                    //    //File.WriteAllLines($"{localAppPath}DinosaurNameAppended.txt", sortedlist);

                    //    break;
                    //}

                    
                    if (pageContent.Contains(dinoName))
                    {
                        shape = dinShapesFileGet[pos2];
                        dinosaurShapes.Add(dinosaurNames[pos] + "                                 " + shape);
                        break;
                    }
                }

                Console.Clear();
                sr.Close();
                //System.Threading.Thread.Sleep(1000);
                pos++;
            }
            catch (WebException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This program is expected to throw WebException on successful run." +
                                    "\n\nException Message :" + e.Message);
                Console.ResetColor();
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                    Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}