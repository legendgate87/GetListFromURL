using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchURL
{
    class Help
    {


        public static void helpUser()
        {
            Console.Clear();
            Console.WriteLine("-Help Section-");
            Console.WriteLine("For info press F1");
            Console.WriteLine("For instructions press F2" + "\r\n");

            var userPressHelp = Console.ReadKey().Key;

            if (userPressHelp == ConsoleKey.F1)
            {
                Console.WriteLine("This is is a URL search tool," + "\r\n" +
                    " created to fetch data from HTML code on a specified URL" + "\r\n" + " and save it to a text file" + "\r\n"+
                    " you will find it in the root derectory of the exe file,"+ "\r\n" + " or if your running this useing VisualStudio it's in searchURL\\bin\\Debug" + "\r\n");               
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
              

            }
             
            else if (userPressHelp == ConsoleKey.F2)
            {
                Console.WriteLine("First input will ask you for a valid URL" + "\r\n" +
                    " Second input will ask you for a searchIndex start term , for example: <P>" + "\r\n" +
                    " Third input will ask you for a searchIndex end term, for example: </P>" + "\r\n" +
                    " The program will then find all <p> and </p>" + "\r\n" + " and save whatever is between <p> and </p> to a text file"+ "\r\n"+
                    "\r\n" +"Press any key to continue"
                    );
              
                Console.ReadLine();

            }
        }
                
        
         }

    }