using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    public class GetDescription : GetPeriod
    {

        //----------------------------------------------------------------------------------        



        public static void runHttpStreamReadDescription()
        {
            DateTime Now = DateTime.Now;

            //string tempPath = Path.GetTempPath(); // C:\Users\UserName\AppData\Local\Temp\

            var localAppPath = AppDomain.CurrentDomain.BaseDirectory;


            foreach (var item in dinosaurNames)
            {
                Console.WriteLine("-------------------------------------");
                dinosaurDescription.ForEach(Console.WriteLine);
                Console.WriteLine("-------------------------------------");

                httpStreamReadDescription();
            }

            //Parallel.ForEach(dinosaurNames, item =>
            //{
                
            //});




            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("DinoList END");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"dinosaurNames: {dinosaurNames.Count()}");
            Console.WriteLine($"dinosaurDescription: {dinosaurDescription.Count()}");
            File.WriteAllLines($"{localAppPath}SearchURL-GetDescription{Now.ToString("yyyyMMdd")}.txt", dinosaurDescription);
            
            //Save to AppDomain.CurrentDomain.BaseDirectory or temPath 
            
        }

        
        


        //--------------------------------------------------------------------------------------------

        public static  void httpStreamReadDescription()
        {


            try
            {
                //  StreamWriter sw = new StreamWriter($"{tempPath}SearchURLGetPeriod-Temp.txt");

                 href = "http://www.nhm.ac.uk/discover/dino-directory/";
                //http://www.dinosaurjungle.com/dinosaur_species_

                Console.WriteLine(pos);
            Console.WriteLine(href + dinosaurNames[pos].ToLower().Replace(" ", "") + ".html");
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(href + dinosaurNames[pos].ToLower().Replace(" ", "")+".html");


             
            HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                

                    StreamReader sr = new StreamReader(myres.GetResponseStream());

            sr.GetLifetimeService();
            
            //while (sr.Peek() > -1)





            int count = 0;
          
            while (!sr.EndOfStream)
            {

                pageContent = sr.ReadToEnd();

            if(pageContent.Contains("acrocanthosaurus"))
                    {
                        Console.ReadLine();
                        Console.WriteLine("acrocanthosaurus---------------");
                    }


                if (pageContent.Contains("omni"))
                    {
                        dinosaurDescription.Add("Omnivore");
                        Console.WriteLine("Found Omnivore, adding to list dinosaurDescription");
                    
                    break;
                   // dinosaurNameAppended.Remove(dinosaurNames[pos]);
                    

                }
                    else if (pageContent.Contains("carni")) {
                        dinosaurDescription.Add("Carnivore");
                        Console.WriteLine("Found Carnivore, adding to list dinosaurDescription");
                    
                    break;
                    //  dinosaurNameAppended.Remove(dinosaurNames[pos]);

                }
                    else if (pageContent.Contains("herbi"))
                    {
                        dinosaurDescription.Add("Herbivore");
                        Console.WriteLine("Found Herbivore, adding to list dinosaurDescription");
                  
                    break;
                        //   dinosaurNameAppended.Remove(dinosaurNames[pos]);

                    }
                    else {
                        dinosaurDescription.Add("NOT FOUND");
                    }

                    count++;
            }

            pos++;
            sr.Close();
            Console.WriteLine($"Done with dinoIndex: {pos}");
            //System.Threading.Thread.Sleep(1000);
            // Console.ReadLine();
            
            Console.Clear();
                
            }
            catch
            {
                
                dinosaurDescription.Add("NOT FOUND");
                Console.WriteLine("404 -- Page not found!, press any key to continue");
                Console.ReadLine();
                
                pos++;
                

            }
        }

    }
}