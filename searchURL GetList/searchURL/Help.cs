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
           var readInputHelp = Console.ReadLine();
            switch(readInputHelp)
            { 
            case ("search"):
                    Console.WriteLine();
                    break;
                case ("info"):
                    // Do stuff
                    break;
            }


        }
                
        
         }

    }